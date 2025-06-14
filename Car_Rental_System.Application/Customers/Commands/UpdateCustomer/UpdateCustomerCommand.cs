using MediatR;

namespace Car_Rental_System.Application.Customers.Commands.UpdateCustomer;
internal class UpdateCustomerCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}


