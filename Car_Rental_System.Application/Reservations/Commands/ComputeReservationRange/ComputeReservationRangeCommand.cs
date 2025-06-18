namespace Car_Rental_System.Application.Reservations.Commands.ComputeRange;
public class ComputeReservationRangeCommand : IRequest<int>
{
    public int ReservationId { get; }

    public ComputeReservationRangeCommand(int reservationId)
    {
        ReservationId = reservationId;
    }
}

