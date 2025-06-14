using AutoMapper;
using Car_Rental_System.Application.Common.Interfaces;
using Car_Rental_System.Domain.Constants;
using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using SharedKernel;
using System.Net;
namespace Car_Rental_System.Application.Auth.Commands.RegisterUser;
internal class RegisterUserCommandHandler(UserManager<User> _userManager, IMapper _mapper, ILogger<RegisterUserCommandHandler> _logger,
    IEmailService _emailService, IUnitOfWork _unitOfWork) : IRequestHandler<RegisterUserCommand, Result<string>>
{

    public async Task<Result<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling RegisterUserCommand for user: {UserName}", request.UserName);

        if (await _userManager.FindByNameAsync(request.UserName) != null)
            return Result<string>.Fail(UserErrors.UsernameTaken);

        if (await _userManager.FindByEmailAsync(request.Email) != null)
            return Result<string>.Fail(UserErrors.EmailAlreadyRegistered);


        var user = _mapper.Map<User>(request);
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return Result<string>.Fail(UserErrors.CreateUserFailed(result.Errors.First().Description));

        await _userManager.AddToRoleAsync(user, Roles.User);
        await _unitOfWork.SaveChangesAsync();

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebUtility.UrlEncode(token);

        var confirmationLink = $"https://localhost:7257/api/auth/confirm-email?userId={user.Id}&token={encodedToken}";

        await _emailService.SendEmailAsync(user.Email, "Confirm your email", $"Click <a href='{confirmationLink}'>here</a> to confirm your email.");

        return Result<string>.Ok(confirmationLink);
    }
}
