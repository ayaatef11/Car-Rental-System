namespace Car_Rental_System.Application.Cars.Commands.RentCar;
    public class RentCarCommand
    {
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


