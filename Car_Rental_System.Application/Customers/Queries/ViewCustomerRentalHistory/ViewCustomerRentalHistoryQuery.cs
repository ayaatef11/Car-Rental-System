using Car_Rental_System.Domain.Entities;
using MediatR;

namespace Car_Rental_System.Application.Customers.Queries.ViewCustomerRentalHistory;

public class ViewCustomerRentalHistoryResult
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<RentalRecordDto> RentalHistory { get; set; } = new();
}

public class RentalRecordDto
{
    public int RentalId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; }
    public string CarModel { get; set; } = string.Empty;
}
internal class ViewCustomerRentalHistoryQuery : IRequest<ViewCustomerRentalHistoryResult>
{
    public int CustomerId { get; set; }
    public ViewCustomerRentalHistoryQuery(int customerId)
        => CustomerId = customerId;
}

