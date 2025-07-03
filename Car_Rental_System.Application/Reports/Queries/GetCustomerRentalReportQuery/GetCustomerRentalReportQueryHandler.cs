namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;
internal class GetCustomerRentalReportQueryHandler(IUnitOfWork _uow) : IRequestHandler<GetCustomerRentalReportQuery, List<CustomerRentalHistoryDto>>
{
    public async Task<List<CustomerRentalHistoryDto>> Handle(GetCustomerRentalReportQuery request, CancellationToken cancellationToken)
    {
        var customer =  _uow.Repository<Customer>().Get(request.customerId);
        var reseravations = customer.Reservations;

        return reseravations.Select(c => new CustomerRentalHistoryDto
        {
            CarId = c.CarId,
            StartDate = c.StartDate,
            EndDate = c.EndDate 
        }).ToList();
    }
}



