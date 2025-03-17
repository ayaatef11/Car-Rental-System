using Car_Rental_System.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//using Car_Rental_System.Models;
//class Program
//{
//    static void Main()
//    {
//        CarRentalSystem system = new CarRentalSystem();
//        int choice = -1;
//        while (choice != 0)
//        {
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.WriteLine("\t\t\t===CAR RENTAL SYSTEM===");
//            Console.WriteLine("Where do you want to go:");
//            Console.WriteLine("\t1. Add Cars and Customers");
//            Console.WriteLine("\t2. Rent a Car");
//            Console.WriteLine("\t3. Return a Car");
//            Console.WriteLine("\t4. View Available Cars");
//            Console.WriteLine("\t5. View Rental History");
//            Console.WriteLine("\t6. Generate Reports");
//            Console.Write("Enter selection: ");

//            if (!int.TryParse(Console.ReadLine(), out choice))
//            {
//                Console.WriteLine("Invalid choice... Try again!");
//                continue;
//            }

//            Console.Clear();

//            switch (choice)
//            {
//                case 1:
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    char ch='y';
//                    do
//                    {
//                        Console.WriteLine("1- Adding a Customer\n2- Adding a Car\n3- Return to Main Menu");
//                        Console.Write("Enter choice: ");
//                        int subChoice;
//                        if (!int.TryParse(Console.ReadLine(), out subChoice))
//                        {
//                            Console.WriteLine("Invalid choice... Try again!");
//                            continue;
//                        }

//                        switch (subChoice)
//                        {
//                            case 1:
//                                system.AddCustomer();
//                                break;
//                            case 2:
//                                system.AddCar();
//                                break;
//                            case 3:
//                                Console.WriteLine("Returning to main menu...");
//                                break;
//                            default:
//                                Console.WriteLine("Invalid choice... Try again!");
//                                break;
//                        }
//                        Console.Write("Continue in the menu? (y/n): ");
//                        ch = Console.ReadKey().KeyChar;
//                        Console.WriteLine();
//                    } while (ch != 'n');
//                    Console.WriteLine("Returning to main menu...");
//                    break;

//                case 2:
//                    Console.ForegroundColor = ConsoleColor.Magenta;
//                    system.RentCar();
//                    break;
//                case 3:
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    system.ReturnCar();
//                    break;
//                case 4:
//                    Console.ForegroundColor = ConsoleColor.Cyan;
//                    system.ViewAllAvailableCars();
//                    break;
//                case 5:
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    system.ViewCustomerRentalHistory();
//                    break;
//                case 6:
//                    Console.ForegroundColor = ConsoleColor.Green;
//                    system.GenerateReports();
//                    break;
//                case 0:
//                    Console.WriteLine("\t\tProgram finished.....Nice time with you :)");
//                    return;
//                default:
//                    Console.WriteLine("Wrong choice... Try again!");
//                    break;
//            }

//            Thread.Sleep(3000);
//            Console.Clear();
//        }
//    }
//}
