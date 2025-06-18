namespace Car_Rental_System.Application.Customers.Queries.ViewCustomerRentalHistory;

public class ViewCustomerRentalHistoryQuery : IRequest<ViewCustomerRentalHistoryResult>
{
    public int CustomerId { get; set; }
    public ViewCustomerRentalHistoryQuery(int customerId)
        => CustomerId = customerId;
}

