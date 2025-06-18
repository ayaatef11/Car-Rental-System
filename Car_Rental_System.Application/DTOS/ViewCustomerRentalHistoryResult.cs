namespace Car_Rental_System.Application.DTOS;
public class ViewCustomerRentalHistoryResult
{
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<RentalRecordDto> RentalHistory { get; set; } = new();
}
