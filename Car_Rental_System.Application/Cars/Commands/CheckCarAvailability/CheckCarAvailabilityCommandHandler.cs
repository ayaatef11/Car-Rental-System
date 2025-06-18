namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

public class CheckCarAvailabilityCommandHandler(IUnitOfWork _unitOfWork)
{

    public async Task<bool> Handle(CheckCarAvailabilityCommand command)
    {
        var car = await _unitOfWork.Repository<Car>().GetByIdAsync(command.CarId);
        if (car == null) throw new Exception("Car not found");

        foreach (var res in car.Reservations)
        {
            if (Overlap(res.StartDate, res.EndDate, command.StartDate, command.EndDate))
            {
                car.Availability = false;
                await _unitOfWork.CompleteAsync();
                return false;
            }
        }

        car.Availability = true;
        await _unitOfWork.CompleteAsync();
        return true;
    }

    private bool Overlap(DateTime resStart, DateTime resEnd, DateTime newStart, DateTime newEnd)
    {
        return resStart <= newEnd && newStart <= resEnd;
    }
}


