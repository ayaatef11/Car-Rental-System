namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;

public record GetCustomerRentalReportQuery(int customerId) : IRequest<List<CustomerRentalHistoryDto>> { }


