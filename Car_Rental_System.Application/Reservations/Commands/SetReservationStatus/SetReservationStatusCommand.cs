using Car_Rental_System.Domain.Constants;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Commands.SetReservationStatus;
internal class SetReservationStatusCommand : IRequest<bool>
{
    public int ReservationId { get; }
    public ReservationStatus Status { get; }

    public SetReservationStatusCommand(int reservationId, ReservationStatus status)
    {
        ReservationId = reservationId;
        Status = status;
    }
}
