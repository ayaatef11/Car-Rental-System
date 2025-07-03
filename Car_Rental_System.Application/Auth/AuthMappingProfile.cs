namespace Car_Rental_System.Application.Auth;
internal class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterUserCommand, AppUser>();

    }
}

