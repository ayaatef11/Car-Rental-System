
namespace Car_Rental_System.Application.Auth.Queries.GetCurrentUser;
public record GetCurrentUserQuery(string Email) : IRequest<Result<UserDto>>;

