namespace Car_Rental_System.Application.Reservations.Commands.UpdateReservation;
internal class UpdateReservationCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<UpdateReservationCommand, Reservation?>
{

    public async Task<Reservation?> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.UpdatedReservation.Id);

        if (reservation == null)
            return null;

        // Optional: selectively update fields
        //reservation.StartDate = request.UpdatedReservation.StartDate;
        //reservation.EndDate = request.UpdatedReservation.EndDate;
        reservation.Status = request.UpdatedReservation.Status;
        reservation.CarId = request.UpdatedReservation.CarId;
        reservation.CustomerId = request.UpdatedReservation.CustomerId;

        _unitOfWork.Repository<Reservation>().Update(reservation);
        await _unitOfWork.SaveChangesAsync();

        return reservation;
    }
}

