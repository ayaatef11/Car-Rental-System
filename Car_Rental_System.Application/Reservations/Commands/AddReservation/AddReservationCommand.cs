namespace Car_Rental_System.Application.Reservations.Commands.AddReservation;
public class AddReservationCommand : IRequest<Result<bool>>
{
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

