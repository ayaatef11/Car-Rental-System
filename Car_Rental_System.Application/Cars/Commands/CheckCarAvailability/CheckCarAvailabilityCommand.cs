namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;
public class CheckCarAvailabilityCommand
{
    public int CarId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}