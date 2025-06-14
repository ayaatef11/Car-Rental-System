﻿using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Customers.Queries.GetAllCustomers;
internal class GetAllCustomersQueryHandler(IUnitOfWork _UOF) : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
{

    public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        return await _UOF.Repository<Customer>().GetAllAsync();
    }  
}

