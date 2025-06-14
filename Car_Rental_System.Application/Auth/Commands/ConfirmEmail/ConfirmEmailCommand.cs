using MediatR;
using SharedKernel;

namespace Car_Rental_System.Application.Auth.Commands.ConfirmEmail;
public record ConfirmEmailCommand(string UserId, string Token) : IRequest<Result<bool>>;

