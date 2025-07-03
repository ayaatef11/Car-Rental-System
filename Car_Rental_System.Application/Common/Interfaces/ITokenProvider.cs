namespace Car_Rental_System.Application.Common.Interfaces;
public interface ITokenProvider
{
    Task<string> GenerateAccessTokenAsync(AppUser user);
    Task<string> GenerateAndStoreRefreshTokenAsync(AppUser user, string jwtId);
}