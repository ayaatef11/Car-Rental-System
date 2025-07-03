
namespace Car_Rental_System.Application.Cars.Commands.UpdateCar;
public class UpdateCarCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<UpdateCarCommand, Result<Car>>
{
    public async Task<Result<Car>> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
    {
        var car = await _unitOfWork.Repository<Car>().GetByIdAsync(command.CarId);

        if (car == null)
            return Result<Car>.Fail(UserErrors.NotFound("Car is not found"));


        car.Make = command.Make;
        car.Model = command.Model;
        car.Year = command.Year;
        car.PricePerDay = command.PricePerDay;
        car.Availability = command.IsAvailable;
        car.UpdatedAt = DateTime.Now;
        _unitOfWork.Repository<Car>().Update(car);
        await _unitOfWork.CompleteAsync();

        return Result<Car>.Ok(car);

    }


}
