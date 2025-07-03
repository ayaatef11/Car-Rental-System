namespace Car_Rental_System.Application.Reservations.Commands.DeleteReservation;
public record DeleteReservationCommand(int ReservationId) : IRequest<bool>
{
}

