using Car_Rental_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reservations.Queries.GetAllReservations;
internal class GetAllReservationsQuery : IRequest<List<Reservation>>
{
}
