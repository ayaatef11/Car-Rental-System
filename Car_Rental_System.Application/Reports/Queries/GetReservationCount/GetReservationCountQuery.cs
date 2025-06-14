using Car_Rental_System.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reports.Queries.GetReservationCount;
internal class GetReservationCountQuery : IRequest<int>
{
    public int CustomerId { get; }

    public GetReservationCountQuery(int customerId)
    {
        CustomerId = customerId;
    }
}

