namespace Car_Rental_System.Models
{
    using System;
    using System.Collections.Generic;

    public abstract class Customer : IComparable<Customer>
    {
        public int Id { get; set; }
        protected int PhoneNumber { get; set; }
        protected List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public Customer() { }
        public Customer(int reservationSize)
        {
            Reservations = new List<Reservation>(reservationSize);
        }
        public Customer(List<Reservation> reservationList)
        {
            Reservations = new List<Reservation>(reservationList);
        }

        public int GetId() => Id;

        public int GetReserveSize() => Reservations.Count;

        public bool CheckSize() => Reservations.Count <= Reservations.Capacity;

        // Adding a reservation
        public bool AddReservation(Reservation r)
        {
            if (Reservations.Count >= Reservations.Capacity)
            {
                Console.WriteLine("You exceeded the utmost number of reservations. You can't add more.");
                return false;
            }
            else
            {
                Reservations.Add(r);
                return true;
            }
        }

        // Deleting a reservation
        public void DeleteReservation(Reservation r)
        {
            Reservations.Remove(r);
        }

        // Operator overloading using IComparable<Customer>
        public int CompareTo(Customer other)
        {
            return Reservations.Count.CompareTo(other.GetReserveSize());
        }

        public static bool operator <(Customer c1, Customer c2) => c1.CompareTo(c2) < 0;
        public static bool operator >(Customer c1, Customer c2) => c1.CompareTo(c2) > 0;
        public static bool operator ==(Customer c1, Customer c2) => c1.CompareTo(c2) == 0;
        public static bool operator !=(Customer c1, Customer c2) => !(c1 == c2);

        public override bool Equals(object obj)
        {
            if (obj is Customer otherCustomer)
                return this.Reservations.Count == otherCustomer.GetReserveSize();
            return false;
        }

        public override int GetHashCode() => Reservations.Count.GetHashCode();

        // Abstract methods to be implemented in derived classes (Person, Company)
        public abstract void ReadData();
        public abstract void PrintData();
    }

}
