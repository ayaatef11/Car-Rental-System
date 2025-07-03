namespace Car_Rental_System.Application.Customers.Queries.GetAllCustomers;
internal class GetAllCustomersQueryHandler(IUnitOfWork _UOF) : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<Customer>>
{

    public async Task<IReadOnlyList<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _UOF.Repository<Customer>().GetAllAsync();
    }  
}

