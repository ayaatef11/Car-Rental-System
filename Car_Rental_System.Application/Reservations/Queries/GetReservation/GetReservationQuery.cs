namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
public record GetReservationQuery(int Id) : IRequest<ReservationDto?>
{
}

