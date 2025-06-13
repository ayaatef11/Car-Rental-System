using Car_Rental_System.Models;
using Car_Rental_System.Repositories;

namespace Car_Rental_System.Services
{
    public class ReservationService(GenericRepository<Reservation> repo,Reservation Reservation)
    {
        public InvoiceService InvoiceService = new InvoiceService(Reservation.Invoice);

        //crud operations
        public void Add(Reservation car)
        {
            repo.Add(car);
        }

        public void Delete(Reservation car)
        {
            repo.Delete(car);
        }

        public Reservation Get(int id) { return repo.Get(id); }
        public Reservation Update(Reservation car)
        {
            return repo.update(car);
        }


        public List<Reservation> GetAll() { return repo.GetAll(); } 
        //logic operations
        public void SetStatus(ReservationStatus status)
        {
            Reservation.Status = status;
        }

        public ReservationStatus GetStatus()
        {
            return Reservation.Status;
        }

        public int ComputePeriod()
        {
            return Reservation.DateRange[1] - Reservation.DateRange[0];
        }
        public void ReadCarId()
        {
            Console.Write("Enter Car ID: ");
            Reservation.CarId = int.Parse(Console.ReadLine() ?? string.Empty);
        }
        public void ReadCustomerId()
        {
            Console.Write("Enter Customer ID: ");
            Reservation.CustomerId = int.Parse(Console.ReadLine() ?? string.Empty);
        }
        public void ReadInvoice()
        {
            Console.Write("Enter Invoice Details: ");
            InvoiceService.ReadTaxes();
        }
    }
}
