using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Car_Rental_System.Application.Common.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Car_Rental_System.Infrastructure.Repositories;
using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;


internal class GetCustomerRentalReportHandler : IRequestHandler<GetCustomerRentalReportQuery, List<CustomerRentalDto>>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerRentalReportHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<List<CustomerRentalDto>> Handle(GetCustomerRentalReportQuery request, CancellationToken cancellationToken)
    {
        var customers = await _uow.Repository<Customer>().GetAllWithRentalsAsync();

        return customers.Select(c => new CustomerRentalDto
        {
            CustomerId = c.Id,
            FullName = c.FullName,
            TotalRentals = c.Rentals.Count
        }).ToList();
    }
}



