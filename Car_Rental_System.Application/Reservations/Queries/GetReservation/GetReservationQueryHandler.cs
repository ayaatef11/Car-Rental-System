namespace Car_Rental_System.Application.Reservations.Queries.GetReservation;
internal class GetReservationQueryHandler(IUnitOfWork _unitOfWork,IMapper _mapper) : IRequestHandler<GetReservationQuery, ReservationDto?>
{
    public async Task<ReservationDto?> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservation= await _unitOfWork.Repository<Reservation>().GetByIdAsync(request.Id);
        var result=_mapper.Map<ReservationDto>(reservation);
        return result;
    }
}

