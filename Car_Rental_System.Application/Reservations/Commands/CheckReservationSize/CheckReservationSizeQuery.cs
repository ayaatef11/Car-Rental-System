namespace Car_Rental_System.Application.Reservations.Commands.CheckReservationSize;
public class CheckReservationSizeQuery : IRequest<bool>
{
    public int CustomerId { get; }

    public CheckReservationSizeQuery(int customerId)
    {
        CustomerId = customerId;
    }
}

