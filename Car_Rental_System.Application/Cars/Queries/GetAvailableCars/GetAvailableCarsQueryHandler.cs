namespace Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
internal class GetAvailableCarsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAvailableCarsQuery, List<Car>>
{
    public async Task<List<Car>> Handle(GetAvailableCarsQuery query, CancellationToken c)
    {
        var repo = _unitOfWork.Repository<Car>();
        var (cars, _) = await repo.GetAllAsync(
            includes: new[] { "Reservations" }
        );
        return cars.Where(car =>
            !car.Reservations.Any(res =>
                res.StartDate <= query.EndDate &&
                query.StartDate <= res.EndDate
            )).ToList();
    }
}
    

