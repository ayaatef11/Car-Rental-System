
namespace Car_Rental_System.Application.Cars.Commands.DeleteCar;
    public class DeleteCarCommand(int carId)
{
    public int CarId { get; set; } = carId;
}

