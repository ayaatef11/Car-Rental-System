namespace Car_Rental_System.Application.Reservations;
internal class ReservationMappingProfile : Profile
{
    public ReservationMappingProfile()
    {
        CreateMap<Reservation, ReservationDto>().ReverseMap();
    }
}

