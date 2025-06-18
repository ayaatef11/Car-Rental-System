namespace Car_Rental_System.Application.Reservations.Commands.DeleteReservation;
internal class DeleteReservationCommand : IRequest<bool>
{
    public int ReservationId { get; }

    public DeleteReservationCommand(int reservationId)
    {
        ReservationId = reservationId;
    }
}

