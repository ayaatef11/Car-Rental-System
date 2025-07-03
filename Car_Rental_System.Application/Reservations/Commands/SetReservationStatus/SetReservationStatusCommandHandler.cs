namespace Car_Rental_System.Application.Reservations.Commands.SetReservationStatus;
internal class SetReservationStatusCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<SetReservationStatusCommand, bool>
{
    public async Task<bool> Handle(SetReservationStatusCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.ReservationId);
        if (reservation == null)
            return false;

        reservation.Status = request.Status;
        _unitOfWork.Repository<Reservation>().Update(reservation);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
