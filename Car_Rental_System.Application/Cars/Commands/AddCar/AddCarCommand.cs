namespace Car_Rental_System.Application.Cars.Commands.AddCar;
public class AddCarCommand : IRequest<int>
{
    public string Make { get; set; } = null!;
    public string Model { get; set; } = null!;
    public int Year { get; set; }
    public bool Availability { get; set; }
}