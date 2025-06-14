using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Car_Rental_System.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Car_Rental_System.Infrastructure.Repositories;
using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Reports.Queries.GetCarRentalReportQuery;

    internal class GetCarRentalReportHandler(IUnitOfWork _uow) : IRequestHandler<GetCarRentalReportQuery, List<CarRentalDto>>
    {
       
        public async Task<List<CarRentalDto>> Handle(GetCarRentalReportQuery request, CancellationToken cancellationToken)
        {
            var cars = await _uow.Repository<Car>().GetAllWithRentalsAsync();

            return cars.Select(car => new CarRentalDto
            {
                CarId = car.Id,
                Model = car.Model,
                RentalCount = car.Rentals.Count
            }).ToList();
        }
    }



