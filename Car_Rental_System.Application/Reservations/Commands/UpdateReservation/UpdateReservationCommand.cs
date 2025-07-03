namespace Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
public record UpdateReservationCommand(int Id,int CarId,int CustomerId, DateTime StartDate, DateTime EndDate) : IRequest<Result<Reservation?>>
{
}

