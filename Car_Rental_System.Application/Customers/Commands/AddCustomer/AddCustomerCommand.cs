

namespace Car_Rental_System.Application.Customers.Commands.AddCustomer;
internal class AddCustomerCommand
{
    public int CustomerType { get; set; } // 1 for Person, 2 for Company
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    // Add any other fields needed

    public AddCustomerCommand(int customerType, string name, string email)
    {
        CustomerType = customerType;
        Name = name;
        Email = email;
    }
}

