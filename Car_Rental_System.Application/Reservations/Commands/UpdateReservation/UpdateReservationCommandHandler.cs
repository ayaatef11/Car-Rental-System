using Car_Rental_System.Application.Cars.Commands.CheckCarAvailability;

namespace Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
internal class UpdateReservationCommandHandler(IUnitOfWork _unitOfWork,IMediator _mediator) : IRequestHandler<UpdateReservationCommand, Result<Reservation?>>
{

    public async Task<Result<Reservation?>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.Id);

        if (reservation == null)
            return Result<Reservation?>.Fail(UserErrors.NotFound("Required Reservation is not found"));

        var checkCommand = new CheckCarAvailabilityCommand(request.CarId, request.StartDate, request.EndDate);
        var availabilityResult = await _mediator.Send(checkCommand);

        if (!availabilityResult.IsSuccess)
            return Result<Reservation?>.Fail(UserErrors.NotFound("Car is not available"));

        reservation.StartDate = request.StartDate;
        reservation.EndDate = request.EndDate;
        reservation.CarId = request.CarId;
        reservation.CustomerId = request.CustomerId;

        _unitOfWork.Repository<Reservation>().Update(reservation);
        await _unitOfWork.SaveChangesAsync();

        return Result<Reservation?>.Ok(reservation);
    }
}

