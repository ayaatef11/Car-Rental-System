
namespace Car_Rental_System.Domain.Constants;
public class Role
{
    public int Id { get; set; } 
    public string Name { get; set; } = null!;
    public string NormalizedName { get; set; } = null!;
}
public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
}