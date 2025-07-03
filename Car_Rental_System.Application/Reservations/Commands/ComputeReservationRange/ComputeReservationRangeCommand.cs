namespace Car_Rental_System.Application.Reservations.Commands.ComputeRange;
public record ComputeReservationRangeCommand(int ReservationId) : IRequest<int>
{
}

