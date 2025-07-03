using Car_Rental_System.Application.Common.Interfaces;

namespace Car_Rental_System.Application.Customers.Commands.UpdateCustomer;
internal class UpdateCustomerCommandHandler(IUnitOfWork _UOF) : IRequestHandler<UpdateCustomerCommand, bool>
{
    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _UOF.Repository<Customer>().GetByIdAsync(request.Id);
        if (customer == null)
            return false;

        customer.FullName = request.FullName;
        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;
        customer.Location = request.Location;
        _UOF.Repository<Customer>().Update(customer);
        await _UOF.CompleteAsync();

        return true;
    }
}

