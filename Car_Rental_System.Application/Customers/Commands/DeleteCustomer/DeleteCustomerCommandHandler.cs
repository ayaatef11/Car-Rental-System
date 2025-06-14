using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
namespace Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
internal class DeleteCustomerCommandHandler(IUnitOfWork _unitOfWork)
{

    public async Task Handle(DeleteCustomerCommand command)
    {
        var customerRepo = _unitOfWork.Repository<Customer>();

        var customer = await customerRepo.GetByIdAsync(command.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found.");
        }

        customerRepo.Delete(customer);
        await _unitOfWork.CompleteAsync();
    }
}


