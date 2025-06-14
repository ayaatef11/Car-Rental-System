using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
    internal class GetAvailableCarsQueryHandler
    {
       
            private readonly IUnitOfWork _unitOfWork;

            public GetAvailableCarsQueryHandler(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<List<Car>> Handle(GetAvailableCarsQuery query)
            {
                var repo = _unitOfWork.Repository<Car>();

                var allCars = await repo.GetAllIncludingAsync(c => c.Reservations);

                return allCars.Where(car =>
                    !car.Reservations.Any(res =>
                        res.StartDate <= query.EndDate && query.StartDate <= res.EndDate
                    )).ToList();
            }
        }
    

