using Car_Rental_System.Application.Reservations.Commands.ComputeRange;

namespace Car_Rental_System.Application.Reservations.Commands.ComputeReservationRange;
internal class ComputeReservationRangeCommandHandler(IUnitOfWork _unitOfWork) : IRequestHandler<ComputeReservationRangeCommand, int>
{
    public async Task<int> Handle(ComputeReservationRangeCommand request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.ReservationId);

        if (reservation == null || reservation.StartDate == null || reservation.EndDate == null)
            return 0;

        return (reservation.EndDate - reservation.StartDate).Days;
    }
}

