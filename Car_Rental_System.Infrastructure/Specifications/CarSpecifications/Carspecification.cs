namespace Car_Rental_System.Infrastructure.Specifications.CarSpecifications;
    internal class Carspecification : BaseSpecification<Car>
{
    public string? Email { get; set; }
    public Carspecification()
    {
        IncludesCriteria.Add(P => P.Reservations!);
    }
    public Carspecification(int id)
    {
        WhereCriteria = P => P.Id == id;

        IncludesCriteria.Add(P => P.Reservations!);
    }
    public Carspecification(string email)
    {
        Email = email;
        //WhereCriteria = p => p.UserEmail == email;
    }
    public Carspecification(CarSpecificationParams param)
    {
        WhereCriteria = P => P.Id == param.Id;

        //IncludesCriteria.Add(P => P.Order!);
    }
}
