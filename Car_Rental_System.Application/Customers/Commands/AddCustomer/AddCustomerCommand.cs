namespace Car_Rental_System.Application.Customers.Commands.AddCustomer;
public class AddCustomerCommand
{
    public int CustomerType { get; set; } 
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public AddCustomerCommand(int customerType, string name, string email)
    {
        CustomerType = customerType;
        Name = name;
        Email = email;
    }
}

