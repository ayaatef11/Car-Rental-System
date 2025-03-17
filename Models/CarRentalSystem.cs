

namespace Car_Rental_System.Models
{
        public class CarRentalSystem
        {
            public int Id { get; set; } 
            private List<Car> cars = new List<Car>();
            private List<Customer> customers = new List<Customer>();
            private Reservation reservation = new Reservation();
            private ReservationStatus status;

            public CarRentalSystem() { }

            public void AddCar()
            {
                Console.WriteLine("Enter car details:");
                Car car = new Car();
                car.ReadData();
                cars.Add(car);
                Console.WriteLine("Car added successfully.");
            }

            public void AddCustomer()
            {
                Console.WriteLine("What kind of customer do you want to add? (1-Person, 2-Company): ");
                int choice = int.Parse(Console.ReadLine()??string.Empty);
                Customer customer = choice switch
                {
                    1 => new Person(),
                    2 => new Company(),
                    _ => throw new Exception("Invalid choice.")
                };
                customer.ReadData();
                customers.Add(customer);
                Console.WriteLine("Customer added successfully.");
            }

            public void RentCar()
            {
                Console.WriteLine("Enter Car ID to rent: ");
                int carId = int.Parse(Console.ReadLine()??string.Empty);
                Car car = cars.FirstOrDefault(c => c.Id == carId);
                if (car == null)
                {
                    Console.WriteLine("Car not found.");
                    return;
                }

                Console.WriteLine("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine()??string.Empty);
                Customer customer = customers.FirstOrDefault(c => c.Id == customerId);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                reservation.ReadInvoice();
                if (car.CheckAvailability(reservation.DateRange[0], reservation.DateRange[1]))
                {
                    car.AddReservation(reservation);
                    customer.AddReservation(reservation);
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
                int carId = int.Parse(Console.ReadLine()??string.Empty);
                Car car = cars.FirstOrDefault(c => c.Id == carId);
                if (car == null)
                {
                    Console.WriteLine("Car not found.");
                    return;
                }

                cars.Remove(car);
                Console.WriteLine("Car returned successfully.");
            }

            public void ViewAllAvailableCars()
            {
            Date endDate, startDate;
            endDate=startDate= new Date(); // Create Date object
            Console.WriteLine("Enter rental start date: ");
            startDate.Read();
            Console.WriteLine("Enter rental end date: ");
            endDate.Read();
            var availableCars = cars.Where(c => c.CheckAvailability(startDate, endDate)).ToList();
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
                int customerId = int.Parse(Console.ReadLine()??string.Empty);
                Customer customer = customers.FirstOrDefault(c => c.Id == customerId);
                if (customer != null)
                    customer.PrintData();
                else
                    Console.WriteLine("Customer not found.");
            }

            public void GenerateReports()
            {
                Console.WriteLine("1- Report on Customers\n2- Report on Cars\nEnter choice: ");
                int choice = int.Parse(Console.ReadLine()??string.Empty);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Customer Rental History:");
                        foreach (var customer in customers)
                        {
                            customer.PrintData();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Car Rental History:");
                        foreach (var car in cars)
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

