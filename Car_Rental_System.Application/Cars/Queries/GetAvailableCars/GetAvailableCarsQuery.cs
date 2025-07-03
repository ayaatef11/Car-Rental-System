namespace Car_Rental_System.Application.Cars.Queries.GetAvailableCars;
public class GetAvailableCarsQuery:IRequest<List<Car>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public GetAvailableCarsQuery(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}



