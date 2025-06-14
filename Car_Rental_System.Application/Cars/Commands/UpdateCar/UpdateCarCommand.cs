

namespace Car_Rental_System.Application.Cars.Commands.UpdateCar;
public class UpdateCarCommand
{
    public int CarId { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
}