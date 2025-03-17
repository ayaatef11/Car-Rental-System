namespace Car_Rental_System.Models
{
    public class Person : Customer
    {
        public string FullName { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;

        public override void ReadData()
        {
            Console.Write("Enter customer's details (ID, Phone Number, Full Name, Address): ");
            Id = int.Parse(Console.ReadLine() ?? string.Empty);
            PhoneNumber = int.Parse(Console.ReadLine() ?? string.Empty);
            FullName = Console.ReadLine()??string.Empty;
            Address = Console.ReadLine() ?? string.Empty;
        }
        public override void PrintData()
        {
            Console.WriteLine("Customer's Details:");
            Console.WriteLine($"ID: {Id} | Phone Number: {PhoneNumber}");
            Console.WriteLine($"Full Name: {FullName} | Address: {Address}");
        }
    }

}
