namespace Car_Rental_System.Application.Reports.Queries.GetRentalReportQuery;
public record GetCarRentalReportQuery(int carId) : IRequest<List<CarRentalDto>> { }
