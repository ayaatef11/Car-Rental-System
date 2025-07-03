
namespace Car_Rental_System.Application.Cars.Queries.GetCarById;
internal class GetCarByIdQueryHandler(IUnitOfWork _UOF):IRequestHandler<GetCarByIdQuery, Car?>
{
    public Task<Car?> Handle(GetCarByIdQuery query, CancellationToken c)
    {
        var car = _UOF.Repository<Car>().Get(query.CarId);
        return Task.FromResult(car); 
    }
}

