namespace Car_Rental_System.Application.DTOS;
public class UserDto
{
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfilePictureUrl { get; set; }
}

