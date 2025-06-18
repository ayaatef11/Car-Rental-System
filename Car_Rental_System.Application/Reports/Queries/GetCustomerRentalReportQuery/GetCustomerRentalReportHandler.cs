namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;
internal class GetCustomerRentalReportHandler(IUnitOfWork _uow) : IRequestHandler<GetCustomerRentalReportQuery, List<CustomerRentalDto>>
{
    public async Task<List<CustomerRentalDto>> Handle(GetCustomerRentalReportQuery request, CancellationToken cancellationToken)
    {
        var customers = await _uow.Repository<Customer>().GetAllWithRentalsAsync();

        return customers.Select(c => new CustomerRentalDto
        {
            CustomerId = c.Id,
            FullName = c.FullName,
            TotalRentals = c.Rentals.Count
        }).ToList();
    }
}



