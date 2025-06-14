using MediatR;
using SharedKernel;

namespace Car_Rental_System.Application.Auth.Commands.ForgetPassword;
public record ForgotPasswordCommand(string Email) : IRequest<Result<string>>;

