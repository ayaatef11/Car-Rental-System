namespace Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }

