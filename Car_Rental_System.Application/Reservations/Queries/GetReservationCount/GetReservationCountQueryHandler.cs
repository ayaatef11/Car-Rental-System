
namespace Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
internal class GetReservationCountQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetReservationCountQuery, int>
{
    public async Task<int> Handle(GetReservationCountQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.Repository<Customer>()
            .GetByIdAsync(request.CustomerId);//WithReservations

        return customer?.Reservations?.Count ?? 0;
    }
}

