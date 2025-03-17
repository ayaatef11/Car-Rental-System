

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

        public bool AddReservation(Reservation r)
        {
            Reservations.Add(r);
            return true;
        }

        public bool CheckAvailability(Date startDate, Date endDate)
        {
            foreach (var res in Reservations)
            {
                if (Overlap(res.DateRange[0], res.DateRange[1], startDate, endDate))
                {
                    Availability = false;
                    return false;
                }
            }
            Availability = true;
            return true;
        }

        public override string ToString()
        {
            string info = $"\n\t===== CAR INFORMATION =====\n" +
                          $"Id: {Id} | Make: {Make} | Model: {Model} | Year: {Year}\n";

            if (Reservations.Count > 0)
            {
                for (int i = 0; i < Reservations.Count; i++)
                {
                    info += $"*** Reservation {i + 1} ***\n";
                    info += Reservations[i].ToString();
                }
            }
            return info;
        }

        public int CompareTo(Car other)
        {
            return Reservations.Count.CompareTo(other.Reservations.Count);
        }

        public static bool Overlap(Date s1, Date d1, Date s2, Date d2)
        {
            return s1 <= d2 && s2 <= d1;  
        }

        public void ReadData()
        {
            Console.Write("Enter Car ID: ");
            Id = int.Parse(Console.ReadLine()??string.Empty);

            Console.Write("Enter Car Make: ");
            Make = Console.ReadLine()??string.Empty;

            Console.Write("Enter Car Model: ");
            Model = Console.ReadLine()??string.Empty;

            Console.Write("Enter Car Year: ");
            Year = int.Parse(Console.ReadLine()??string.Empty);

            Console.Write("Is the car available? (yes/no): ");
            string availabilityInput = Console.ReadLine().ToLower();
            Availability = availabilityInput == "yes";
        }
        public void WriteData()
        {
            Console.WriteLine("\n===== CAR INFORMATION =====");
            Console.WriteLine($"ID: {Id} | Make: {Make} | Model: {Model} | Year: {Year} | Available: {Availability}");
        }
    }

}
