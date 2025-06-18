namespace Car_Rental_System.Application.Reports.Queries.GetCarRentalReportQuery;

    internal class GetCarRentalReportHandler(IUnitOfWork _uow) : IRequestHandler<GetCarRentalReportQuery, List<CarRentalDto>>
    {   
        public async Task<List<CarRentalDto>> Handle(GetCarRentalReportQuery request, CancellationToken cancellationToken)
        {
            var cars = await _uow.Repository<Car>().GetAllAsync();//WithRentalsAsync

        return cars.Select(car => new CarRentalDto
            {
                CarId = car.Id,
                Model = car.Model,
                //RentalCount = car.Rentals.Count
            }).ToList();
        }
    }



