
namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

public class CheckCarAvailabilityCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<CheckCarAvailabilityCommand,Result<bool>>
{
    public async Task<Result<bool>> Handle(CheckCarAvailabilityCommand command, CancellationToken cancellationToken)
    {
        var car = await _unitOfWork.Repository<Car>().GetByIdAsync(command.CarId);
        if (car == null) return Result<bool>.Fail(UserErrors.NotFound("Car not found"));


        foreach (var res in car.Reservations)
        {
            if (Overlap(res.StartDate, res.EndDate, command.StartDate, command.EndDate))
            {
                car.Availability = false;
                await _unitOfWork.CompleteAsync();
                return Result<bool>.Fail(UserErrors.NotFound("overlabs"));
            }
        }

        car.Availability = true;
        await _unitOfWork.CompleteAsync();
        return Result<bool>.Ok(true);
    }


    private bool Overlap(DateTime resStart, DateTime resEnd, DateTime newStart, DateTime newEnd)
    {
        return resStart <= newEnd && newStart <= resEnd;
    }
}


