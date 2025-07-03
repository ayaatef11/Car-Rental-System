namespace Car_Rental_System.Application.Auth.Commands.Logout;
internal class LogoutCommandHandelr(IRefreshTokenRepository _refreshTokenRepository, IUserContext _userContext) : IRequestHandler<LogoutCommand, Result>
{
    public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var userId = _userContext.UserId;
        if (userId == null)
            return Result.Fail(AuthErrors.Unauthorized);

        var tokens = await _refreshTokenRepository.GetByUserIdAsync(userId);

        foreach (var token in tokens)
            token.IsRevoked = true;

        await _refreshTokenRepository.SaveChangesAsync();

        return Result.Ok();

    }
}

