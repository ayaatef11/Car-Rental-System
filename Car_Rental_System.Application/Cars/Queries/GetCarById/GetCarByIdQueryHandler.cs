using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;

namespace Car_Rental_System.Application.Cars.Queries.GetCarById;
internal class GetCarByIdQueryHandler(IUnitOfWork _UOF)
{

    public Car? Handle(GetCarByIdQuery query)
    {
        return _UOF.Repository<Car>().Get(query.CarId);
    }
}

