
namespace Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
internal class GetAvailableCarsQueryHandler(IUnitOfWork _unitOfWork)
{

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
    

