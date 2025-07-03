namespace Car_Rental_System.Application.Customers.Commands.AddCustomer;

    public record AddCustomerCommand(string PhoneNumber, string FullName,string Email,string Location) : IRequest<int>
{ }


