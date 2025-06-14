using Car_Rental_System.Domain.Constants;
using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservationStatus;
internal class GetReservationStatusQueryHandler : IRequestHandler<GetReservationStatusQuery, ReservationStatus?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationStatusQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ReservationStatus?> Handle(GetReservationStatusQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.ReservationId);
        return reservation?.Status;
    }
}

