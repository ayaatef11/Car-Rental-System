using Car_Rental_System.Application.Reports.Queries.GetCarRentalReportQuery;
using Car_Rental_System.Application.Reports.Queries.GetCustomerRentalReportQuery;

namespace Car_Rental_System.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]


public class ReportsController(IMediator mediator) : ControllerBase
{
    [HttpGet("car-rentals")]
    [EndpointSummary("Get car rental report")]
    public async Task<IActionResult> GetCarRentalReport()
    {
        var result = await mediator.Send(new GetCarRentalReportQuery());
        return Ok(ApiResponse<List<CarRentalReportDto>>.Success(result));
    }

    [HttpGet("customer-rentals")]
    [EndpointSummary("Get customer rental report")]
    public async Task<IActionResult> GetCustomerRentalReport()
    {
        var result = await mediator.Send(new GetCustomerRentalReportQuery());
        return Ok(ApiResponse<List<CustomerRentalReportDto>>.Success(result));
    }
}


