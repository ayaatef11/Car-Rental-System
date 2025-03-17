namespace Car_Rental_System.Models
{

    public class Company : Customer
    {
        public string Location { get; set; } = string.Empty;
        public string CompanyName { get; set; }= string.Empty;

        public override void ReadData()
        {
            Console.Write("Enter customer's details (ID, Phone Number, Name, Location): ");
            Id = int.Parse(Console.ReadLine()??string.Empty);
            PhoneNumber =int.Parse( Console.ReadLine()??string.Empty);
            CompanyName = Console.ReadLine()??string.Empty;
            Location = Console.ReadLine()??string.Empty;
        }

        public override void PrintData()
        {
            Console.WriteLine($"ID: {Id} | Phone Number: {PhoneNumber}");
            Console.WriteLine($"Company Name: {CompanyName} | Location: {Location}");
        }
    }

}
