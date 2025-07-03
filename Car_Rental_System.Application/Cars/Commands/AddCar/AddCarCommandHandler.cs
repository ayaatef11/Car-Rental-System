namespace Car_Rental_System.Application.Cars.Commands.AddCar;

public class AddCarCommandHandler(IUnitOfWork _UOF) : IRequestHandler<AddCarCommand, int>
{
    public async Task<int> Handle(AddCarCommand request, CancellationToken cancellationToken)
    {
        var car = new Car
        {
            Make = request.Make,
            Model = request.Model,
            Year = request.Year,
            Availability = request.Availability
        };

        await _UOF.Repository<Car>().AddAsync(car);
        await _UOF.SaveChangesAsync();
        return car.Id;
    }
}
