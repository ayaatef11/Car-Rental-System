namespace Car_Rental_System.Application.Customers.Queries.GetCustomer;
public class GetCustomerQuery : IRequest<Customer?>
{
    public int Id { get; set; }

    public GetCustomerQuery(int id)
    {
        Id = id;
    }
}

