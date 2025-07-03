namespace Car_Rental_System.Application.Cars.Commands.DeleteCar;
public class DeleteCarCommand(int carId):IRequest<int>
{
    public int CarId { get; set; } = carId;
}

