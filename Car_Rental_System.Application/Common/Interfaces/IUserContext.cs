
namespace Car_Rental_System.Application.Common.Interfaces;
public interface IUserContext
{
    string? UserId { get; }
    bool IsInRole(string role);
}
