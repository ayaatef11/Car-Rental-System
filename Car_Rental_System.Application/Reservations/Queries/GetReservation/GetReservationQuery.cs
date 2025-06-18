namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
public class GetReservationQuery : IRequest<Reservation?>
{
    public int Id { get; }

    public GetReservationQuery(int id)
    {
        Id = id;
    }
}

