using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand
    {
        public int CarId { get; set; }

        public DeleteCarCommand(int carId)
        {
            CarId = carId;
        }
    }
}
