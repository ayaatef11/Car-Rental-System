namespace Car_Rental_System.Application.Auth.Commands.ResetEmailConfirmation;
public record ResetEmailConfirmationCommand(string email) : IRequest<Result<RegisterUserDto>>;

