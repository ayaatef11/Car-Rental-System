namespace Car_Rental_System.Application.Cars.Queries.GetCarById;
    internal class GetCarByIdQuery
    {
        public int CarId { get; }

        public GetCarByIdQuery(int carId)
        {
            CarId = carId;
        }
    }


