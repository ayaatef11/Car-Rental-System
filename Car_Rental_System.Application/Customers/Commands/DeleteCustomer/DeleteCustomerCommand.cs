namespace Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
    public record DeleteCustomerCommand(int CustomerId):IRequest<int>
    {
    }

