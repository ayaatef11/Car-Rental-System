namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
internal class GetReservationQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetReservationQuery, Reservation?>
{
    public async Task<Reservation?> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.Id);
    }
}

