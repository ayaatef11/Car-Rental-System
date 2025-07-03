namespace Car_Rental_System.Application.Reservations.Queries.GetAllReservations;
internal class GetAllReservationsQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllReservationsQuery, IEnumerable<Reservation>>
{
    public async Task<IEnumerable<Reservation>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Repository<Reservation>().GetAllAsync();
    }
}

