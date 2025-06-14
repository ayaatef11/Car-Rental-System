using Car_Rental_System.Application.Common.Interfaces;
using Car_Rental_System.Domain.Entities;
using global::Car_Rental_System.Infrastructure.Repositories;

namespace Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

    public class CheckCarAvailabilityCommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CheckCarAvailabilityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckCarAvailabilityCommand command)
        {
            var car = await _unitOfWork.Repository<Car>().GetByIdAsync(command.CarId);
            if (car == null) throw new Exception("Car not found");

            foreach (var res in car.Reservations)
            {
                if (Overlap(res.DateRange[0], res.DateRange[1], command.StartDate, command.EndDate))
                {
                    car.Availability = false;
                    await _unitOfWork.CompleteAsync();
                    return false;
                }
            }

            car.Availability = true;
            await _unitOfWork.CompleteAsync();
            return true;
        }

        private bool Overlap(Date resStart, Date resEnd, Date newStart, Date newEnd)
        {
            return resStart <= newEnd && newStart <= resEnd;
        }
    }


