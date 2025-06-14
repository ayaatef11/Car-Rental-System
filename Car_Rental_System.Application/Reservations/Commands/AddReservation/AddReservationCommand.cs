using Car_Rental_System.Domain.Entities;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Commands.AddReservation;
internal class AddReservationCommand : IRequest<bool>
{
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime ReservationDate { get; set; }
    public decimal Amount { get; set; }
    // ... Add other fields if needed
}

