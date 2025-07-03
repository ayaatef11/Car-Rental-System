namespace Car_Rental_System.Application.Auth.Commands.ForgetPassword;
public class ForgotPasswordCommandHandler(UserManager<AppUser> _userManager, IEmailService _emailService) : IRequestHandler<ForgotPasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return Result<string>.Fail(UserErrors.NotFound(request.Email));
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encodedToken = WebUtility.UrlEncode(token);

        var resetLink = $"https://localhost:7257/api/auth/reset-password?userId={user.Id}&token={encodedToken}";

        await _emailService.SendEmailAsync(
            user.Email,
            "Reset your password",
            $"Click <a href='{resetLink}'>here</a> to reset your password.");

        return Result<string>.Ok(resetLink);
    }
}
