using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
internal class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, Reservation?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Reservation?> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.Id);
    }
}

