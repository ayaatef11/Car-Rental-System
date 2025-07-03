namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;
public record CheckCarAvailabilityCommand(int CarId, DateTime StartDate, DateTime EndDate) : IRequest<Result<bool>>
{ }