namespace Car_Rental_System.Domain.Entities;
public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Location { get; set; } = null!;
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
}
