
using Car_Rental_System.Application.Specifications.CarSpecifications;

namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

public class CheckCarAvailabilityCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<CheckCarAvailabilityCommand,Result<bool>>
{
    public async Task<Result<bool>> Handle(CheckCarAvailabilityCommand command, CancellationToken cancellationToken)
    {
        var spec = new Carspecification(command.CarId);
        var car = await _unitOfWork.Repository<Car>().GetByIdWithSpecAsync(spec);
        if (car == null) return Result<bool>.Fail(CarErrors.NotFound("Car not found"));


        foreach (var res in car.Reservations)
        {
            if (Overlap(res.StartDate, res.EndDate, command.StartDate, command.EndDate))
            {
                car.Availability = false;
                await _unitOfWork.CompleteAsync();
                return Result<bool>.Fail(CarErrors.NotFound("overlabs"));
            }
        }

        car.Availability = true;
        await _unitOfWork.CompleteAsync();
        return Result<bool>.Ok(true);
    }


    private bool Overlap(DateTime resStart, DateTime resEnd, DateTime newStart, DateTime newEnd)
    {
        return (resStart <= newEnd && newStart <= resEnd)||(resStart == newEnd && newStart == resEnd);
    }
}


