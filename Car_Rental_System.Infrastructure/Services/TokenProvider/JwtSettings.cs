namespace Car_Rental_System.Infrastructure.Services.TokenProvider;
internal class JwtSettings
{
    public const string Section = "JwtSettings";
    public string Secret { get; set; } = null!;
    public int TokenExpirationInMinutes { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
}
