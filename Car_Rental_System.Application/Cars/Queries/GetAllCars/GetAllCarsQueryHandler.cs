namespace Car_Rental_System.Application.Cars.Queries.GetAllCars;
    internal class GetAllCarsQueryHandler(IUnitOfWork _unitOfWork):IRequestHandler<GetAllCarsQuery,IEnumerable<Car>>
    {     
        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery query,CancellationToken c)
        {
            var cars = await _unitOfWork.Repository<Car>().GetAllAsync();
            return cars;
        }
    }

