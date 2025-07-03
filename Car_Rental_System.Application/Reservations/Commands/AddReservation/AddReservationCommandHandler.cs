using Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

namespace Car_Rental_System.Application.Reservations.Commands.AddReservation;
internal class AddReservationCommandHandler(IUnitOfWork _uow,IMediator _mediator) : IRequestHandler<AddReservationCommand,Result< bool>>
{
    public async Task<Result<bool>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
    {
        var car = await _uow.Repository<Car>().GetByIdAsync(request.CarId);
        var customer = await _uow.Repository<Customer>().GetByIdAsync(request.CustomerId);//WithReservations

        if (car == null )
            return Result<bool>.Fail(CarErrors.NotFound("required car is not found"));
        if(customer == null)
            return Result<bool>.Fail(CustomerErrors.NotFound("required customer is not found"));

        var checkCommand = new CheckCarAvailabilityCommand(request.CarId, request.StartDate, request.EndDate);
        var availabilityResult = await _mediator.Send(checkCommand);

        if (!availabilityResult.IsSuccess)
            return Result<bool>.Fail(CarErrors.NotFound("Required car is not available"));

        var reservation = new Reservation
        {
            Car = car,
            Customer = customer,
            StartDate = request.StartDate,
            EndDate = request.EndDate
        };

        await _uow.Repository<Reservation>().AddAsync(reservation);
        await _uow.SaveChangesAsync();
        return Result<bool>.Ok(true);
    }
}

