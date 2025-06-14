
using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Common.Interfaces;
public interface ITokenProvider
{
    Task<string> GenerateAccessTokenAsync(User user);
    Task<string> GenerateAndStoreRefreshTokenAsync(User user, string jwtId);
}