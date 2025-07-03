namespace Car_Rental_System.Domain.Entities;
public class AppUser : IdentityUser
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? ProfilePictureUrl { get; set; } 
    public string? ProfilePictureBlobName { get; set; }
    public Social Social { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}


