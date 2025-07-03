namespace Car_Rental_System.Infrastructure.Mapping;
internal interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}

