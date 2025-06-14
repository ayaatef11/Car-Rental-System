using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Domain.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedKernel;
namespace Car_Rental_System.Application.Auth.Commands.ResetPassword;
public class ResetPasswordCommandHandler(UserManager<User> _userManager) : IRequestHandler<ResetPasswordCommand, Result>
{
    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.userId);
        if (user == null)
        {
            return Result.Fail(UserErrors.NotFound(request.userId));
        }

        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);

        if (!result.Succeeded)
            return Result.Fail(AuthErrors.InvalidToken);

        return Result.Ok();
    }
}
