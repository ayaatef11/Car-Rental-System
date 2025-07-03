namespace Car_Rental_System.Application.Reservations.Queries.GetReservationStatus;
public class GetReservationStatusQuery : IRequest<ReservationStatus?>
{
    public int ReservationId { get; }

    public GetReservationStatusQuery(int reservationId)
    {
        ReservationId = reservationId;
    }
}

