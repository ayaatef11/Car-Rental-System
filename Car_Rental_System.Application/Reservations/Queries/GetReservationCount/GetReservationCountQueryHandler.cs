using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
internal class GetReservationCountQueryHandler : IRequestHandler<GetReservationCountQuery, int>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetReservationCountQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> Handle(GetReservationCountQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Repository<Customer>()
            .GetByIdWithReservationsAsync(request.CustomerId);

        return customer?.Reservations?.Count ?? 0;
    }
}

