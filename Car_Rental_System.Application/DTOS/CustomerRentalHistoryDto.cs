
namespace Car_Rental_System.Application.DTOS;
public class CustomerRentalHistoryDto
{
    public int CustomerId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int TotalRentals { get; set; }
}

