namespace Car_Rental_System.Domain.Entities;
    public class Person : Customer
    {
        public string FullName { get; set; }=string.Empty;
        public string Address { get; set; } = string.Empty;      
    }
