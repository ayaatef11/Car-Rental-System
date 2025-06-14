using Car_Rental_System.Domain.Constants;
using Microsoft.AspNetCore.Identity;


namespace Car_Rental_System.Domain.Entities;
public class User : IdentityUser
{
    public string? FirstName { get; set; } = default!;
    public string? LastName { get; set; } = default!;
    public DateOnly? DateOfBirth { get; set; }
    public string? ProfilePictureUrl { get; set; } = default!;
    public string? ProfilePictureBlobName { get; set; } = default!;
    public string? Bio { get; set; } = default!;
    public string? WebsiteUrl { get; set; }
    public string? Country { get; set; } = default!;
    public Social Social { get; set; } = default!;

    public ICollection<UserFollow> Followers { get; set; } = new List<UserFollow>();
    public ICollection<UserFollow> Following { get; set; } = new List<UserFollow>();

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


