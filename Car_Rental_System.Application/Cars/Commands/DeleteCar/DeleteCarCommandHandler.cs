using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
namespace Car_Rental_System.Application.Cars.Commands.DeleteCar;
public class DeleteCarCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCarCommand command)
    {
        var carRepo = _unitOfWork.Repository<Car>();
        var car = await carRepo.GetByIdAsync(command.CarId);
        if (car == null)
        {
            throw new Exception("Car not found");
        }

        carRepo.Delete(car);
        await _unitOfWork.CompleteAsync();
    }
}
