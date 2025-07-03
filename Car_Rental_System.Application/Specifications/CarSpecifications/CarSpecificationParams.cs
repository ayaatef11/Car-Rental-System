namespace Car_Rental_System.Application.Specifications.CarSpecifications;
public class CarSpecificationParams
{
    public int Id { get; set; }
    private const int MaxPageSize = 10;

    private int pageSize = 5;
    public int PageIndex { get; set; } = 1;
    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = value > MaxPageSize ? pageSize : value; }
    }
    public int? ReservationId { get; set; }
}


