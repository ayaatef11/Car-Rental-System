namespace Car_Rental_System.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
   public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
