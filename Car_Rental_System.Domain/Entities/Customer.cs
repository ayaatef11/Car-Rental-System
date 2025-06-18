namespace Car_Rental_System.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public int PhoneNumber { get; set; }
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
