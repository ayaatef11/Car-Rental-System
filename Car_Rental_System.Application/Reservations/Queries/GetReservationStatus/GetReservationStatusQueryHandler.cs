namespace Car_Rental_System.Application.Reservations.Queries.GetReservationStatus;
internal class GetReservationStatusQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetReservationStatusQuery, ReservationStatus?>
{
    public async Task<ReservationStatus?> Handle(GetReservationStatusQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.ReservationId);
        return reservation?.Status;
    }
}

