namespace Car_Rental_System.Application.Auth.Commands.ForgetPassword;
public class ForgotPasswordCommandHandler(UserManager<AppUser> _userManager, IEmailService _emailService) : IRequestHandler<ForgotPasswordCommand, Result<RegisterUserDto>>
{
    public async Task<Result<RegisterUserDto>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return Result<RegisterUserDto>.Fail(UserErrors.NotFound(request.Email));
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var encodedToken = WebUtility.UrlEncode(token);

        var resetLink = $"https://localhost:7117/api/Auth/reset-password?userId={user.Id}&token={encodedToken}";
        var registerUser = new RegisterUserDto
        {
            UserId = user.Id,
            Token = token
        };
        await _emailService.SendEmailAsync(
            user.Email,
            "Reset your password",
            $"Click <a href='{resetLink}'>here</a> to reset your password.");

        return Result<RegisterUserDto>.Ok(registerUser);
    }
}
