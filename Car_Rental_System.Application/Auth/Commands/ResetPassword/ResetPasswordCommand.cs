using MediatR;
using SharedKernel;

namespace Car_Rental_System.Application.Auth.Commands.ResetPassword;
public record ResetPasswordCommand(string userId, string Token, string NewPassword) : IRequest<Result>;

