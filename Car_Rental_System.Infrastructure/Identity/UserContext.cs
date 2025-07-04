﻿namespace Car_Rental_System.Infrastructure.Identity;
internal sealed class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public string? UserId =>
     httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

    public bool IsInRole(string role) => httpContextAccessor.HttpContext?.User?.IsInRole(role) ?? false;
}