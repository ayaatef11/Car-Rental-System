namespace Car_Rental_System.Application.Cars.Commands.ReturnCar;
public class ReturnCarCommandHandler(IUnitOfWork _uof)
{
    public void Handle(ReturnCarCommand command)
    {
        var car = _uof.Repository<Car>().Get(command.CarId);
        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        _uof.Repository<Car>().Delete(car);
    }
}
