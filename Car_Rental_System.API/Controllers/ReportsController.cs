using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Car_Rental_System.Application.Reports.Queries;
using Car_Rental_System.Domain.DTOs;
using Car_Rental_System.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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


