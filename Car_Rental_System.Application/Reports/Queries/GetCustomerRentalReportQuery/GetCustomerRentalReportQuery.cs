using MediatR;

namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;
public class CustomerRentalDto
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int TotalRentals { get; set; }
}
internal class GetCustomerRentalReportQuery : IRequest<List<CustomerRentalDto>> { }


