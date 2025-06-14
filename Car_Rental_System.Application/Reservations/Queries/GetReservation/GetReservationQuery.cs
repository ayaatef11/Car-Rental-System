using Car_Rental_System.Domain.Entities;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
internal class GetReservationQuery : IRequest<Reservation?>
{
    public int Id { get; }

    public GetReservationQuery(int id)
    {
        Id = id;
    }
}

