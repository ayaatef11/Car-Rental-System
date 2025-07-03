namespace Car_Rental_System.Domain.Entities;
public class Reservation  
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public Invoice? Invoice { get; set; }

}
