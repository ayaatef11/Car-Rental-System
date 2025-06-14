using Car_Rental_System.Application.DTOS;
using MediatR;
using SharedKernel;

namespace Car_Rental_System.Application.Auth.Commands.RefreshToken;

public record RefreshTokenCommand(string RefreshToken) : IRequest<Result<AuthResultDto>>;

