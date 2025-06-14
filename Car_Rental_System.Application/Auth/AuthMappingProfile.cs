
using AutoMapper;
using Car_Rental_System.Application.Auth.Commands.RegisterUser;
using Car_Rental_System.Domain.Entities;

namespace Car_Rental_System.Application.Auth;
internal class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterUserCommand, User>();

    }
}

