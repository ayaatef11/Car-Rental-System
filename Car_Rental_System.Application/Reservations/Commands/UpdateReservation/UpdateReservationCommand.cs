using Car_Rental_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
public class UpdateReservationCommand : IRequest<Reservation?>
{
    public Reservation UpdatedReservation { get; }

    public UpdateReservationCommand(Reservation updatedReservation)
    {
        UpdatedReservation = updatedReservation;
    }
}

