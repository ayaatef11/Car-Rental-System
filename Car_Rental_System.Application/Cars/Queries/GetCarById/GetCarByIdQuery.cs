namespace Car_Rental_System.Application.Cars.Queries.GetCarById;
public class GetCarByIdQuery(int carId):IRequest<Car?>
{
    public int CarId { get; } = carId;
}


