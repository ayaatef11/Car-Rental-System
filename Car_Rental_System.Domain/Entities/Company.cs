namespace Car_Rental_System.Domain.Entities;
    public class Company : Customer
    {
        public string Location { get; set; } = string.Empty;
        public string CompanyName { get; set; }= string.Empty;    
    }
