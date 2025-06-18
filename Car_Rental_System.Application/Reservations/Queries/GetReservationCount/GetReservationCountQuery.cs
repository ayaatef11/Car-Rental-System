namespace Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
public class GetReservationCountQuery : IRequest<int>
{
    public int CustomerId { get; }

    public GetReservationCountQuery(int customerId)
    {
        CustomerId = customerId;
    }
}

