namespace Car_Rental_System.Application.Cars.Commands.AddCar;
public class AddCarCommand : IRequest<int>
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public bool Availability { get; set; }
}