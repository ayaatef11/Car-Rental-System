using Car_Rental_System.Application.Common.Interfaces;
using Car_Rental_System.Domain.Entities;
using global::Car_Rental_System.Domain.Entities;
using global::Car_Rental_System.Infrastructure.Repositories;
namespace Car_Rental_System.Application.Cars.Commands.RentCar;
    internal class RentCarCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(RentCarCommand command)
        {
            var car = await _unitOfWork.Repository<Car>().GetByIdAsync(command.CarId);
            if (car == null) return "Car not found.";

            var customer = await _unitOfWork.Repository<Customer>().GetByIdAsync(command.CustomerId);
            if (customer == null) return "Customer not found.";

            // Check for availability
            bool isAvailable = !car.Reservations.Any(r =>
                r.StartDate <= command.EndDate && command.StartDate <= r.EndDate);

            if (!isAvailable)
            {
                return "Car not available for the selected period.";
            }

            // Create reservation
            var reservation = new Reservation
            {
                Car = car,
                Customer = customer,
                //StartDate = command.StartDate,
                //EndDate = command.EndDate
            };

            car.Reservations.Add(reservation);
            customer.Reservations.Add(reservation);

            await _unitOfWork.CompleteAsync();

            return "Reservation completed successfully.";
        }
    }

