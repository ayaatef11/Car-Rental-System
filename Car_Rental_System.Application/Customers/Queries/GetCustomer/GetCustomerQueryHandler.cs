namespace Car_Rental_System.Application.Customers.Queries.GetCustomer;
internal class GetCustomerQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetCustomerQuery, Customer?>
{

    public async Task<Customer?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Customer>().GetByIdAsync(request.Id);
    }
}
    
