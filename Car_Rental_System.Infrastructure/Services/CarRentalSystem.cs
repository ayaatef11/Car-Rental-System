using Car_Rental_System.Models;
using Car_Rental_System.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Car_Rental_System.Services
{
    [NotMapped]
    public class CarRentalSystem
    {
        public int Id { get; set; }
        public UnitOfwork uf { get; set; }
        public Car car { get; set; }
        public Customer customer { get; set; }
        public Reservation reservation { get; set; }


        private CarService carsService ;
        private CustomerService customersService ;
        private ReservationService reservationService;
        private ReservationStatus status;

       
        public CarRentalSystem(UnitOfwork unitOfWork)
        {
            uf = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            CarService carsService = new CarService(uf.Repository<Car>(), car);
            CustomerService customersService = new CustomerService(uf.Repository<Customer>(), customer);
            ReservationService reservationService = new ReservationService(uf.Repository<Reservation>(), reservation);

        }
        public void AddCar()
        {
            Console.WriteLine("Enter car details:");
            carsService.ReadData();
            carsService.Add(car);
            Console.WriteLine("Car added successfully.");
        }

        public void AddCustomer()
        {
            Console.WriteLine("What kind of customer do you want to add? (1-Person, 2-Company): ");
            int choice = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer customer = choice switch
            {
                1 => new Person(),
                2 => new Company(),
                _ => throw new Exception("Invalid choice.")
            };
            customersService.ReadData();
            customersService.Add(customer);
            Console.WriteLine("Customer added successfully.");
        }

        public void RentCar()
        {
            Console.WriteLine("Enter Car ID to rent: ");
            int carId = int.Parse(Console.ReadLine() ?? string.Empty);
            Car car = carsService.Get(carId); 
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            Console.WriteLine("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer customer = customersService.Get(customerId);
            if (customer == null)
            {
                Console.WriteLine("Customer not found.");
                return;
            }

            reservationService.ReadInvoice();
            if (carsService.CheckAvailability(reservation.DateRange[0], reservation.DateRange[1]))
            {
                carsService.AddReservation(reservation);
                customersService.AddReservation(reservation);
                Console.WriteLine("Reservation completed successfully.");
            }
            else
            {
                Console.WriteLine("Car not available for the selected period.");
            }
        }

        public void ReturnCar()
        {
            Console.WriteLine("Enter Car ID to return: ");
            int carId = int.Parse(Console.ReadLine() ?? string.Empty);
            Car car = carsService.Get(carId);
            if (car == null)
            {
                Console.WriteLine("Car not found.");
                return;
            }

            carsService.Delete(car);
            Console.WriteLine("Car returned successfully.");
        }

        public void ViewAllAvailableCars()
        {
            Date endDate, startDate;
            endDate = startDate = new Date(); // Create Date object
            Console.WriteLine("Enter rental start date: ");
            startDate.Read();
            Console.WriteLine("Enter rental end date: ");
            endDate.Read();
            var availableCars = carsService.GetAvailableCars(startDate,endDate);
            if (availableCars.Any())
            {
                foreach (var car in availableCars)
                    Console.WriteLine(car);
            }
            else
            {
                Console.WriteLine("No available cars found.");
            }
        }

        public void ViewCustomerRentalHistory()
        {
            Console.WriteLine("Enter Customer ID: ");
            int customerId = int.Parse(Console.ReadLine() ?? string.Empty);
            Customer customer = customersService.Get(customerId);
            if (customer != null)
                customersService.PrintData();
            else
                Console.WriteLine("Customer not found.");
        }

        public void GenerateReports()
        {
            Console.WriteLine("1- Report on Customers\n2- Report on Cars\nEnter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? string.Empty);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Customer Rental History:");
                    List<Customer> customerList = customersService.GetAll();
                    foreach (var customer in customerList )
                    {
                        customersService.PrintData();
                    }
                    break;
                case 2:
                    Console.WriteLine("Car Rental History:");
                    List<Car> carlist=carsService.GetAll();
                    foreach (var car in carlist)
                    {
                        Console.WriteLine(car);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

