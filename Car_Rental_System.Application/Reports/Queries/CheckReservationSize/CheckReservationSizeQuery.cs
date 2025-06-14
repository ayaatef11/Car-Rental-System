using Car_Rental_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reports.Queries.CheckReservationSize;
internal class CheckReservationSizeQuery : IRequest<bool>
{
    public int CustomerId { get; }

    public CheckReservationSizeQuery(int customerId)
    {
        CustomerId = customerId;
    }
}

