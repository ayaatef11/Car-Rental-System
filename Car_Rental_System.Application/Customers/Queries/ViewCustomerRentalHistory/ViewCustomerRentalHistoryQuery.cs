namespace Car_Rental_System.Application.Customers.Queries.ViewCustomerRentalHistory;
public record ViewCustomerRentalHistoryQuery(int CustomerId) : IRequest<ViewCustomerRentalHistoryResult>
{
}

