using Car_Rental_System.Models;
using Car_Rental_System.Repositories;

namespace Car_Rental_System.Services
{
    public  class CustomerService(GenericRepository<Customer> repo, Customer Customer)
    {


        //crud operations 

        public void Add(Customer car)
        {
            repo.Add(car);
        }

        public void Delete(Customer car)
        {
            repo.Delete(car);
        }

        public Customer Get(int id) { return repo.Get(id); }

        public Customer Update(Customer car)
        {
            return repo.update(car);
        }

        public List<Customer> GetAll() { return repo.GetAll(); }    
        public int GetId() => Customer.Id;

        public int GetReserveSize() => Customer.Reservations.Count;

        public bool CheckSize() => Customer.Reservations.Count <= Customer.Reservations.Capacity;

        public bool AddReservation(Reservation r)
        {
            if (Customer.Reservations.Count >= Customer.Reservations.Capacity)
            {
                Console.WriteLine("You exceeded the utmost number of reservations. You can't add more.");
                return false;
            }
            else
            {
                Customer.Reservations.Add(r);
                return true;
            }
        }

        public void DeleteReservation(Reservation r)
        {
            Customer.Reservations.Remove(r);
        }
        public override bool Equals(object obj)
        {
            if (obj is Customer otherCustomer)
                return Customer.Reservations.Count == this.GetReserveSize();
            return false;
        }

        public override int GetHashCode() => Customer.Reservations.Count.GetHashCode();

        public  void ReadData()
        {
            Console.Write("Enter customer's details (ID, Phone Number, Name, Location): ");
            Customer.Id = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer.PhoneNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            //it depends on the type of the customer 
           // Customer.CompanyName = Console.ReadLine() ?? string.Empty;
           // Customer.Location = Console.ReadLine() ?? string.Empty;
        }

        public  void PrintData()
        {
            Console.WriteLine($"ID: {Customer.Id} | Phone Number: {Customer.PhoneNumber}");
            //Console.WriteLine($"Company Name: {Customer.CompanyName} | Location: {Customer.Location}");
        }
    }
}
