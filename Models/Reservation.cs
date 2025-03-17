namespace Car_Rental_System.Models
{
    public enum ReservationStatus { NotCompleted, Completed, Canceled, Still }

    public class Reservation : IComparable<Reservation>
    {
        public int Id { get; set; }
        //public Tuple<Date, Date> DateRange { get; set; }
        //public Date StartDate { get; set; }
        //public Date EndDate { get; set; }
        public List<Date> DateRange { get; set; } = new List<Date>();  // ✅ Navigation Property
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public Invoice Invoice { get; set; }
        public ReservationStatus Status { get; set; }
        public Reservation()
        {
            Car = null;
            Customer = null;
            CustomerId = 0;
            Invoice = new Invoice();
        }
        public Reservation(Car car)
        {
            Car = car;
        }
        public Reservation(Reservation other)
        {
            DateRange = other.DateRange;
            Car = new Car();
            Car = other.Car;
        }
        public void SetStatus(ReservationStatus status)
        {
            Status = status;
        }

        public ReservationStatus GetStatus()
        {
            return Status;
        }

        public int ComputePeriod()
        {
            return DateRange[1]- DateRange[0];
        }
        public void ReadCarId()
        {
            Console.Write("Enter Car ID: ");
            CarId = int.Parse(Console.ReadLine()??string.Empty);
        }
        public void ReadCustomerId()
        {
            Console.Write("Enter Customer ID: ");
            CustomerId = int.Parse(Console.ReadLine()??string.Empty);
        }
        public void ReadInvoice()
        {
            Console.Write("Enter Invoice Details: ");
            Invoice.ReadTaxes();
        }
        public override string ToString()
        {
            return $"\nStart Date: {DateRange[0]} | End Date: {DateRange[1]} \nInvoice Details: {Invoice}";
        }
        public int CompareTo(Reservation other)
        {
            return Invoice.CalculateTotalAmountDue().CompareTo(other.Invoice.CalculateTotalAmountDue());
        }
        public static bool operator <(Reservation r1, Reservation r2) => r1.CompareTo(r2) < 0;
        public static bool operator >(Reservation r1, Reservation r2) => r1.CompareTo(r2) > 0;
        public static bool operator ==(Reservation r1, Reservation r2) => r1.CompareTo(r2) == 0;
        public static bool operator !=(Reservation r1, Reservation r2) => !(r1 == r2);

        public override bool Equals(object obj)
        {
            if (obj is Reservation reservation)
                return this == reservation;
            return false;
        }

        public override int GetHashCode() => Invoice.CalculateTotalAmountDue().GetHashCode();
    }

}
