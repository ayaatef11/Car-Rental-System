using MediatR;

namespace Car_Rental_System.Application.Reports.Queries.GetCarRentalReportQuery;
public class CarRentalDto
{
    public int CarId { get; set; }
    public string Model { get; set; } = string.Empty;
    public int RentalCount { get; set; }
}
internal class GetCarRentalReportQuery : IRequest<List<CarRentalDto>> { }
