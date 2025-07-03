using Car_Rental_System.Application.Reports.Queries.GetRentalReportQuery;

namespace Car_Rental_System.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class ReportsController(IMediator mediator) : ControllerBase
{
    [HttpGet("car-rentals/{id}")]
    [EndpointSummary("Get car rental report")]
    public async Task<IActionResult> GetCarRentalReport(int id)
    {
        var result = await mediator.Send(new GetCarRentalReportQuery(id));
        return Ok(ApiResponse<List<CarRentalDto>>.Success(result));
    }

    [HttpGet("customer-rentals/{id}")]
    [EndpointSummary("Get customer rental report")]
    public async Task<IActionResult> GetCustomerRentalReport(int id)
    {
        var result = await mediator.Send(new GetCustomerRentalReportQuery(id));
        return Ok(ApiResponse<List<CustomerRentalHistoryDto>>.Success(result));
    }
}


