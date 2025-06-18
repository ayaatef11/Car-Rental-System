namespace Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
public class UpdateReservationCommand : IRequest<Reservation?>
{
    public Reservation UpdatedReservation { get; }

    public UpdateReservationCommand(Reservation updatedReservation)
    {
        UpdatedReservation = updatedReservation;
    }
}

