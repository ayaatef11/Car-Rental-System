namespace Car_Rental_System.Application.Cars.Commands.DeleteCar;
public class DeleteCarCommandHandler(IUnitOfWork _unitOfWork):IRequestHandler<DeleteCarCommand,int>
{
    public async Task<int> Handle(DeleteCarCommand command,CancellationToken c)
    {
        var carRepo = _unitOfWork.Repository<Car>();
        var car = await carRepo.GetByIdAsync(command.CarId);
        if (car == null)
        {
            throw new Exception("Car not found");
        }

        carRepo.Delete(car);
       return  await _unitOfWork.CompleteAsync();
    }
}
