namespace Car_Rental_System.Application.Auth.Commands.ConfirmEmail;
internal class ConfirmEmailCommandHandler(UserManager<AppUser> _userManager) : IRequestHandler<ConfirmEmailCommand, Result<bool>>
{
    public async Task<Result<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return Result<bool>.Fail(UserErrors.NotFound(request.UserId));

        if (user.EmailConfirmed)
            return Result<bool>.Fail(UserErrors.EmailAlreadyConfirmed(request.UserId));

        var result = await _userManager.ConfirmEmailAsync(user, request.Token);

        if (!result.Succeeded)
            return Result<bool>.Fail(AuthErrors.InvalidToken);

        return Result<bool>.Ok(true);
    }
}
