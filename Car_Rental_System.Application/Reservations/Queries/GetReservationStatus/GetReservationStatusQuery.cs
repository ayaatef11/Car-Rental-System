using Car_Rental_System.Domain.Constants;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservationStatus;
internal class GetReservationStatusQuery : IRequest<ReservationStatus?>
{
    public int ReservationId { get; }

    public GetReservationStatusQuery(int reservationId)
    {
        ReservationId = reservationId;
    }
}

