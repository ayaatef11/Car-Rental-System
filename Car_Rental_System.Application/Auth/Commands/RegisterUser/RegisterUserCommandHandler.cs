namespace Car_Rental_System.Application.Auth.Commands.RegisterUser;
internal class RegisterUserCommandHandler(UserManager<AppUser> _userManager, IMapper _mapper, ILogger<RegisterUserCommandHandler> _logger,
    IEmailService _emailService, IUnitOfWork _unitOfWork) : IRequestHandler<RegisterUserCommand, Result<RegisterUserDto>>
{

    public async Task<Result<RegisterUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling RegisterUserCommand for user: {UserName}", request.UserName);

        if (await _userManager.FindByNameAsync(request.UserName) != null)
            return Result<RegisterUserDto>.Fail(UserErrors.UsernameTaken);

        if (await _userManager.FindByEmailAsync(request.Email) != null)
            return Result<RegisterUserDto>.Fail(UserErrors.EmailAlreadyRegistered);


        var user = _mapper.Map<AppUser>(request);
        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return Result<RegisterUserDto>.Fail(UserErrors.CreateUserFailed(result.Errors.First().Description));

        await _userManager.AddToRoleAsync(user, Roles.User.ToString());
        await _unitOfWork.SaveChangesAsync();

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebUtility.UrlEncode(token);

        var confirmationLink = $"https://localhost:7117/api/Auth/confirm-email?userId={user.Id}&token={encodedToken}";
        var registerUser = new RegisterUserDto
        {
            UserId = user.Id,
            Token = token
        };
        if(user.Email==null)
            return Result<RegisterUserDto>.Fail(UserErrors.NotFound(result.Errors.First().Description));


        await _emailService.SendEmailAsync(user.Email, "Confirm your email", $"Click <a href='{confirmationLink}'>here</a> to confirm your email.");

        return Result<RegisterUserDto>.Ok(registerUser);
    }
}
