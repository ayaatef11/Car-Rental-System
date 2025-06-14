using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Repositories;
using MediatR;

namespace Car_Rental_System.Application.Reservations.Commands.AddReservation;
internal class AddReservationCommandHandler(IUnitOfWork _uow) : IRequestHandler<AddReservationCommand, bool>
{
    private const int MaxReservationsPerCustomer = 5;

    public async Task<bool> Handle(AddReservationCommand request, CancellationToken cancellationToken)
    {
        var car = await _uow.Repository<Car>().GetByIdAsync(request.CarId);
        var customer = await _uow.Repository<Customer>().GetByIdWithReservationsAsync(request.CustomerId);

        if (car == null || customer == null)
            return false;

        if (customer.Reservations.Count >= MaxReservationsPerCustomer)
            return false;

        var reservation = new Reservation
        {
            Car = car,
            Customer = customer,
            //ReservationDate = request.ReservationDate,
            //Amount = request.Amount
            // ... set other properties if needed
        };

        await _uow.Repository<Reservation>().AddAsync(reservation);
        await _uow.SaveChangesAsync();
        return true;
    }
}

