using Car_Rental_System.Application.Specifications.CarSpecifications;

namespace Car_Rental_System.Application.Reports.Queries.GetRentalReportQuery;

internal class GetCarsRentalReportHandler(IUnitOfWork _uow) : IRequestHandler<GetCarRentalReportQuery, List<CarRentalDto>>
{
    public async Task<List<CarRentalDto>> Handle(GetCarRentalReportQuery request, CancellationToken cancellationToken)
    {
        var spec = new Carspecification(request.carId);
        var car = await _uow.Repository<Car>().GetByIdWithSpecAsync(spec);
        if (car == null) return null;

        var reservations = car.Reservations;

        return [.. reservations.Select(reservation => new CarRentalDto
            {
                CustomerId =reservation.CustomerId,
                StartDate = reservation.StartDate,
                EndDate = reservation.EndDate
            })];
    }
}



