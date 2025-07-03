namespace Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
public record GetReservationCountQuery(int CustomerId) : IRequest<int>
{
}

