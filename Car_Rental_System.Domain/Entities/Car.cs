

namespace Car_Rental_System.Models
{
    public class Car : IComparable<Car>
    {
        public int Id { get; set; }
        public string Make { get; set; }=string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public bool Availability { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Car(List<Reservation> reservations)
        {
            Reservations = new List<Reservation>(reservations);
        }

        public Car() { }
        public int CompareTo(Car other)
        {
            return Reservations.Count.CompareTo(other.Reservations.Count);
        }

        
    }

}
