namespace Car_Rental_System.Application.Auth.Queries.GetCurrentUser;
public class GetCurrentUserQueryHandler(UserManager<AppUser> _userManager,ILogger<GetCurrentUserQueryHandler>_logger) : IRequestHandler<GetCurrentUserQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Email))
            {
                return Result<UserDto>.Fail(UserErrors.NotFound(request.Email));
            }

            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogWarning($"User not found for email: {request.Email}");
                return Result<UserDto>.Fail(UserErrors.NotFound(request.Email));
            }

            var roles = await _userManager.GetRolesAsync(user);

            var userDto = new UserDto
            {
                Id=user.Id,
                Username = user.UserName,   
            };

            return Result<UserDto>.Ok(userDto);
     
    }
}
