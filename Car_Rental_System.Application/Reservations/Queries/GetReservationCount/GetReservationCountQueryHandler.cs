using Car_Rental_System.Application.Specifications.CustomerSpecifications;

namespace Car_Rental_System.Application.Reservations.Queries.GetReservationCount;
internal class GetReservationCountQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetReservationCountQuery, int>
{
    public async Task<int> Handle(GetReservationCountQuery request, CancellationToken cancellationToken)
    {
        var spec = new CustomerSpecification(request.CustomerId);
        var customer = await _unitOfWork.Repository<Customer>().GetByIdWithSpecAsync(spec);

        return customer?.Reservations?.Count ?? 0;
    }
}

