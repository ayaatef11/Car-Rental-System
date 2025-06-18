namespace Car_Rental_System.Application.Cars.Commands.ReturnCar;
public class ReturnCarCommand(int carId)
{
    public int CarId { get; } = carId;
}

