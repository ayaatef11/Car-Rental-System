namespace Car_Rental_System.Domain.Entities;
    public  class Customer : IComparable<Customer>
    {
        public int Id { get; set; }
        public int PhoneNumber { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
      
        public Customer() { }
        public Customer(int reservationSize)
        {
            Reservations = new List<Reservation>(reservationSize);
        }
        public Customer(List<Reservation> reservationList)
        {
            Reservations = new List<Reservation>(reservationList);
        }

        public int CompareTo(Customer other)
        {
            return Reservations.Count.CompareTo(other.Reservations.Count());
        }


        public static bool operator <(Customer c1, Customer c2) => c1.CompareTo(c2) < 0;
        public static bool operator >(Customer c1, Customer c2) => c1.CompareTo(c2) > 0;
        public static bool operator ==(Customer c1, Customer c2) => c1.CompareTo(c2) == 0;
        public static bool operator !=(Customer c1, Customer c2) => !(c1 == c2);
}
