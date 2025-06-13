using Car_Rental_System.Models;

namespace Car_Rental_System.Services
{
    public class DateService(Date Date)
    {
        public void Read()
        {
            Console.Write("Enter date (day/month/year): ");
            string input = Console.ReadLine()??string.Empty; // Example: "16/03/2025"

            string[] parts = input.Split('/'); 
            if (parts.Length == 3)
            {
                Date.Day = int.Parse(parts[0]);
                Date.Month = int.Parse(parts[1]);
                Date.Year = int.Parse(parts[2]);
            }
            else
            {
                Console.WriteLine("Invalid date format. Please use day/month/year.");
            }
        }
    }
}
