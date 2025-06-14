using Car_Rental_System.Domain.Entities;
using MediatR;

namespace Car_Rental_System.Application.Customers.Queries.GetAllCustomers;
    internal class GetAllCustomersQuery : IRequest<List<Customer>>
    {

    }

