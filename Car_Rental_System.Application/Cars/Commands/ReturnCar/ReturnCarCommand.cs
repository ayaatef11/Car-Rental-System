namespace Car_Rental_System.Application.Cars.Commands.ReturnCar;
public class ReturnCarCommand
{
    public int CarId { get; }

    public ReturnCarCommand(int carId)
    {
        CarId = carId;
    }
}

