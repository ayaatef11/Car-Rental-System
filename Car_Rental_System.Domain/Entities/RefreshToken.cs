
namespace Car_Rental_System.Domain.Entities;
public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = null!;
    public string JwtId { get; set; } = null!;
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string UserId { get; set; } = null!;
    public required AppUser User { get; set; }
}
