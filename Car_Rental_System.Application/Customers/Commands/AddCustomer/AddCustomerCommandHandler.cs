using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
namespace Car_Rental_System.Application.Customers.Commands.AddCustomer;
internal class AddCustomerCommandHandler(IUnitOfWork _unitOfWork)
{

    public async Task Handle(AddCustomerCommand command)
    {
        Customer customer = command.CustomerType switch
        {
            1 => new Person { FullName = command.Name },
            2 => new Company { CompanyName = command.Name },
            _ => throw new Exception("Invalid customer type.")
        };

        var customerRepo = _unitOfWork.Repository<Customer>();
        customerRepo.AddAsync(customer);
        await _unitOfWork.CompleteAsync();
    }
}

