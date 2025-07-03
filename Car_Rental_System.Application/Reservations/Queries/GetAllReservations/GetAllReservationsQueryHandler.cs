namespace Car_Rental_System.Application.Reservations.Queries.GetAllReservations;
internal class GetAllReservationsQueryHandler(IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<GetAllReservationsQuery, IReadOnlyList<ReservationDto>>
{
    public async Task<IReadOnlyList<ReservationDto>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
    {
        var reservations= await _unitOfWork.Repository<Reservation>().GetAllAsync();
        var result = _mapper.Map<IReadOnlyList<ReservationDto>>(reservations);
        return result;
    }
}

