namespace Car_Rental_System.Application.Auth.Commands.ResetEmailConfirmation;
public class ResetEmailConfirmationCommandHandler(UserManager<AppUser> _userManager, IEmailService _emailService) : IRequestHandler<ResetEmailConfirmationCommand, Result<RegisterUserDto>>
{

    public async Task<Result<RegisterUserDto>> Handle(ResetEmailConfirmationCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.email);
        if (user == null)
            return Result<RegisterUserDto>.Fail(UserErrors.NotFound(request.email));

        if (user.EmailConfirmed)
            return Result<RegisterUserDto>.Fail(UserErrors.EmailAlreadyConfirmed(user.Id));

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var encodedToken = WebUtility.UrlEncode(token);

        var confirmationLink = $"https://localhost:7117/api/Auth/confirm-email?userId={user.Id}&token={encodedToken}";
        var registerUser = new RegisterUserDto
        {
            UserId = user.Id,
            Token = token
        };
        await _emailService.SendEmailAsync(
            user.Email, "Confirm your email",
            $"Click <a href='{confirmationLink}'>here</a> to confirm your email.");

        return Result<RegisterUserDto>.Ok(registerUser);
    }
}

