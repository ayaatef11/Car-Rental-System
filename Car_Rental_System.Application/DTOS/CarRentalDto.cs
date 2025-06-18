
namespace Car_Rental_System.Application.DTOS;
public class CarRentalDto
{
    public int CarId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int RentalCount { get; set; }
}
