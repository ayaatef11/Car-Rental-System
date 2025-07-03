namespace Car_Rental_System.Application.Reports.Queries.GetRentalReportQuery;

    internal class GetCarsRentalReportHandler(IUnitOfWork _uow) : IRequestHandler<GetCarRentalReportQuery, List<CarRentalDto>>
    {   
        public async Task<List<CarRentalDto>> Handle(GetCarRentalReportQuery request, CancellationToken cancellationToken)
        {
            var car =  _uow.Repository<Car>().Get(request.carId);
            var reservations=car.Reservations;

        return [.. reservations.Select(reservation => new CarRentalDto
            {
                CustomerId =reservation.CustomerId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            })];
        }
    }



