namespace Car_Rental_System.Domain.Entities;
public class Invoice
{
    public int Id { get; set; }
    public double RentalCharges { get; set; }
    public double Taxes { get; set; }
    public double TotalAmountDue { get; set; }
    public Reservation Reservation { get; set; }
}
