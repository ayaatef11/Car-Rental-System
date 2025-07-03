namespace Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
internal class DeleteCustomerCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<DeleteCustomerCommand,int>
{
    public async Task<int> Handle(DeleteCustomerCommand command,CancellationToken c)
    {
        var customerRepo = _unitOfWork.Repository<Customer>();

        var customer = await customerRepo.GetByIdAsync(command.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found.");
        }

        customerRepo.Delete(customer);
       return await _unitOfWork.CompleteAsync();
    }
}


