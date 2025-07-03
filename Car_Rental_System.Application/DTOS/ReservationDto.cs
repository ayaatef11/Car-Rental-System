namespace Car_Rental_System.Application.DTOS;
public class ReservationDto
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }

}

