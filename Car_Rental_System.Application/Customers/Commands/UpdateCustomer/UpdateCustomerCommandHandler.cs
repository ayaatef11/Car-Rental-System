using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Application.Common.Interfaces;
using MediatR;
using Car_Rental_System.Infrastructure.Repositories;

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

            await _UOF.Repository<Customer>().Update(customer);
            return true;
        }
    }

