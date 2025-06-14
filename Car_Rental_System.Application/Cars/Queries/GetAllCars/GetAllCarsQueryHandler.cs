using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
namespace Car_Rental_System.Application.Cars.Queries.GetAllCars
{
    internal class GetAllCarsQueryHandler(IUnitOfWork _unitOfWork)
    {     
        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery query)
        {
            var cars = await _unitOfWork.Repository<Car>().GetAllAsync();
            return cars;
        }
    }
}

