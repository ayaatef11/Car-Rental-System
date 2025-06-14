using Car_Rental_System.Domain.Entities;
using MediatR;

namespace Car_Rental_System.Application.Customers.Queries.GetCustomer;
internal class GetCustomerQuery : IRequest<Customer?>
{
    public int Id { get; set; }

    public GetCustomerQuery(int id)
    {
        Id = id;
    }
}

