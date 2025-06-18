using Car_Rental_System.Domain.Constants;

namespace Car_Rental_System.Domain.Entities;

public class Reservation  
{
    public int Id { get; set; }
    public Tuple<Date, Date> DateRange { get; set; }
    public Date StartDate { get; set; }
    public Date EndDate { get; set; }
    public Car Car { get; set; }
    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
    public int CarId { get; set; }
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public ReservationStatus Status { get; set; }

}
