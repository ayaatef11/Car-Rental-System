using Car_Rental_System.Infrastructure.Specifications;

namespace Car_Rental_System.Application.Specifications.CarSpecifications;
public class Carspecification : BaseSpecification<Car>
{
    public Carspecification()
    {
        IncludesCriteria.Add(P => P.Reservations!);
    }
    public Carspecification(int id)
    {
        WhereCriteria = P => P.Id == id;

        IncludesCriteria.Add(P => P.Reservations!);
    }
    public Carspecification(CarSpecificationParams param)
    {
        WhereCriteria = P => P.Id == param.Id;

        IncludesCriteria.Add(P => P.Reservations!);
    }
}
