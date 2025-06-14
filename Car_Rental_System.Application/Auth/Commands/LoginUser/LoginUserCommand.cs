using Car_Rental_System.Application.DTOS;
using MediatR;
using SharedKernel;

namespace Car_Rental_System.Application.Auth.Commands.LoginUser;
public record LoginUserCommand(string UsernameOrEmail, string Password) : IRequest<Result<AuthResultDto>>;
