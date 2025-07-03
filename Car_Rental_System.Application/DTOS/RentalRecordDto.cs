namespace Car_Rental_System.Application.DTOS;
public class RentalRecordDto
{
    public int RentalId { get; set; }
    public DateTime RentedOn { get; set; }
    public DateTime? ReturnedOn { get; set; }
    public string CarModel { get; set; } = string.Empty;
}
