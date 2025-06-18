namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;
internal class GetCustomerRentalReportQueryHandler(IUnitOfWork _uow) : IRequestHandler<GetCustomerRentalReportQuery, List<CustomerRentalHistoryDto>>
{
    public async Task<List<CustomerRentalHistoryDto>> Handle(GetCustomerRentalReportQuery request, CancellationToken cancellationToken)
    {
        var customers = await _uow.Repository<Customer>().GetAllAsync();//WithRentals

        return customers.Select(c => new CustomerRentalHistoryDto
        {
            CustomerId = c.Id,
            FullName = c.FullName,
            //TotalRentals = c.Rental\s.Count
        }).ToList();
    }
}



