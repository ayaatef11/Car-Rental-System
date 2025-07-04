﻿namespace Car_Rental_System.Infrastructure.Services.TokenProvider;
internal class JwtTokeProvider : ITokenProvider
{
    private readonly JwtSettings _jwtSettings;
    private readonly UserManager<AppUser> _userManager;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public JwtTokeProvider(
        IOptions<JwtSettings> jwtSettings,
        UserManager<AppUser> userManager,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _userManager = userManager;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<string> GenerateAccessTokenAsync(AppUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes);


        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<string> GenerateAndStoreRefreshTokenAsync(AppUser user, string jwtId)
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        var refreshToken = new RefreshToken
        {
            Token = token,
            JwtId = jwtId,
            UserId = user.Id,
            IsUsed = false,
            IsRevoked = false,
            ExpiryDate = DateTime.UtcNow.AddDays(7),
            User=user
        };

        await _refreshTokenRepository.AddAsync(refreshToken);
        await _refreshTokenRepository.SaveChangesAsync();

        return refreshToken.Token;
    }
}
