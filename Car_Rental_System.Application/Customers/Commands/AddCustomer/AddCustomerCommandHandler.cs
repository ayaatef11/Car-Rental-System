namespace Car_Rental_System.Application.Customers.Commands.AddCustomer;
internal class AddCustomerCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<AddCustomerCommand,int>
{
    public async Task<int> Handle(AddCustomerCommand command,CancellationToken c)
    {
        Customer customer = new Customer { FullName = command.FullName,Email=command.Email,Location=command.Location,PhoneNumber=command.PhoneNumber };
        var customerRepo = _unitOfWork.Repository<Customer>();
       await customerRepo.AddAsync(customer);
       return await _unitOfWork.CompleteAsync();
    }
}

