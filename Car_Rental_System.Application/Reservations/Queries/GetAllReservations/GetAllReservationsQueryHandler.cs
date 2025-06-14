using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Queries.GetAllReservations;
internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<Reservation>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllReservationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Reservation>().GetAllAsync();
    }
}

