using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Reports.Queries.CheckReservationSize;
    internal class CheckReservationSizeQueryHandler : IRequestHandler<CheckReservationSizeQuery, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int MaxReservationLimit = 5; 

        public CheckReservationSizeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CheckReservationSizeQuery request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.Repository<Car>().GetByIdWithReservationsAsync(request.CustomerId);

            if (customer == null || customer.Reservations == null)
                return false;

            return customer.Reservations.Count <= MaxReservationLimit;
        }
    }


