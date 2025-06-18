namespace Car_Rental_System.Application.Cars.Commands.UpdateCar;


public class UpdateCarCommandHandler(IUnitOfWork unitOfWork)
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Car?> Handle(UpdateCarCommand command)
    {
        var repo = _unitOfWork.Repository<Car>();
        var car = await repo.GetByIdAsync(command.CarId);

        if (car == null) return null;

        car.Make = command.Make;
        car.Model = command.Model;
        car.Year = command.Year;
        car.PricePerDay = command.PricePerDay;
        car.Availability = command.IsAvailable;

        repo.Update(car);
        await _unitOfWork.CompleteAsync();

        return car;
    }
}
