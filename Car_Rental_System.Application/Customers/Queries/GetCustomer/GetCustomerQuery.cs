namespace Car_Rental_System.Application.Customers.Queries.GetCustomer;
public record GetCustomerQuery(int Id) : IRequest<Customer?>
{
}

