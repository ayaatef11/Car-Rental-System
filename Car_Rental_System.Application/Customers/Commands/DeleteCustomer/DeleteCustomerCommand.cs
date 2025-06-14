using Car_Rental_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Customers.Commands.DeleteCustomer;
    internal class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }

        public DeleteCustomerCommand(int customerId)
        {
            CustomerId = customerId;
        }
    }

