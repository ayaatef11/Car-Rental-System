namespace Car_Rental_System.Application.Customers.Commands.UpdateCustomer;
public record UpdateCustomerCommand(int Id,string FullName,string PhoneNumber, string Email,string Location) : IRequest<bool>
{
}


