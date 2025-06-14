
using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Common.Interfaces;
public interface IRefreshTokenRepository
{
    Task AddAsync(RefreshToken token);
    Task<RefreshToken?> GetByTokenAsync(string token);
    Task<IEnumerable<RefreshToken>> GetByUserIdAsync(string userId);
    Task SaveChangesAsync();
}