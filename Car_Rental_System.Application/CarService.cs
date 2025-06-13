using Car_Rental_System.Data;
using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Services
{
    public class CarService(GenericRepository<Car>repo,Car Car)
    {
        //crud  in database 
        public void Add(Car car)
        {
            repo.Add(car);
        }

        public void Delete(Car car)
        {
            repo.Delete(car);
        }

        public Car Get(int id) {  return repo.Get(id); }
        public Car Update(Car car)
        {
            return repo.update(car);
        }
      public List<Car> GetAll()
        {
            return repo.GetAll();
        }
        //logic in program 
        public bool AddReservation(Reservation r)
        {
            Car.Reservations.Add(r);
            return true;
        }

        public bool CheckAvailability(Date startDate, Date endDate)
        {
            foreach (var res in Car.Reservations)
            {
                if (Overlap(res.DateRange[0], res.DateRange[1], startDate, endDate))
                {
                    Car.Availability = false;
                    return false;
                }
            }
            Car.Availability = true;
            return true;
        }

        public List<Car> GetAvailableCars(Date startDate, Date endDate)
        {
            return repo._context.Cars
                .Where(c => this.CheckAvailability(startDate, endDate))
                .ToList();
        }

        public override string ToString()
        {
            string info = $"\n\t===== CAR INFORMATION =====\n" +
                          $"Id: {Car.Id} | Make: {Car.Make} | Model: {Car.Model} | Year: {Car.Year}\n";

            if (Car.Reservations.Count > 0)
            {
                for (int i = 0; i < Car.Reservations.Count; i++)
                {
                    info += $"*** Reservation {i + 1} ***\n";
                    info += Car.Reservations[i].ToString();
                }
            }
            return info;
        }

        public static bool Overlap(Date s1, Date d1, Date s2, Date d2)
        {
            return s1 <= d2 && s2 <= d1;
        }

        public void ReadData()
        {
            Console.Write("Enter Car ID: ");
            Car.Id = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Enter Car Make: ");
            Car.Make = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Car Model: ");
            Car.Model = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Car Year: ");
            Car.Year = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.Write("Is the car available? (yes/no): ");
            string availabilityInput = Console.ReadLine().ToLower();
            Car.Availability = availabilityInput == "yes";
        }
        public void WriteData()
        {
            Console.WriteLine("\n===== CAR INFORMATION =====");
            Console.WriteLine($"ID: {Car.Id} | Make: {Car.Make} | Model: {Car.Model} | Year: {Car.Year} | Available: {Car.Availability}");
        }
    }
}
