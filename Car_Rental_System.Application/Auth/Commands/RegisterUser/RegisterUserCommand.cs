namespace Car_Rental_System.Application.Auth.Commands.RegisterUser;
public class RegisterUserCommand : IRequest<Result<RegisterUserDto>>
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}


