namespace Car_Rental_System.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class ReservationsController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [EndpointSummary("Add a new reservation")]
    public async Task<IActionResult> AddReservation([FromBody] AddReservationCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Reservation added successfully"));
    }

    [HttpDelete("delete")]
    [EndpointSummary("Delete reservation")]
    public async Task<IActionResult> DeleteReservation([FromBody] DeleteReservationCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse.Success("Reservation deleted successfully"));
    }

    [HttpPut("update")]
    [EndpointSummary("Update reservation")]
    public async Task<IActionResult> UpdateReservation([FromBody] UpdateReservationCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<Reservation>.Success(result, "Reservation updated"));
    }

    [HttpPut("set-status")]
    [EndpointSummary("Set reservation status")]
    public async Task<IActionResult> SetReservationStatus([FromBody] SetReservationStatusCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse.Success("Status updated"));
    }

    [HttpGet("all")]
    [EndpointSummary("Get all reservations")]
    public async Task<IActionResult> GetAllReservations()
    {
        var result = await mediator.Send(new GetAllReservationsQuery());
        return Ok(ApiResponse<List<Reservation>>.Success(result));
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get reservation by ID")]
    public async Task<IActionResult> GetReservation(int id)
    {
        var result = await mediator.Send(new GetReservationQuery(id));
        return Ok(ApiResponse<Reservation>.Success(result));
    }

    [HttpGet("count")]
    [EndpointSummary("Get total reservation count")]
    public async Task<IActionResult> GetReservationCount(int customerId)
    {
        var result = await mediator.Send(new GetReservationCountQuery(customerId));
        return Ok(ApiResponse<int>.Success(result));
    }

    [HttpGet("status")]
    [EndpointSummary("Get reservation status")]
    public async Task<IActionResult> GetReservationStatus(int reservationId)
    {
        var result = await mediator.Send(new GetReservationStatusQuery(reservationId));
        return Ok(ApiResponse<string>.Success(result.ToString()));
    }

    [HttpGet("charge")]
    [EndpointSummary("Get rental charges")]
    public async Task<IActionResult> GetRentalCharge(int invoiceId)
    {
        var result = await mediator.Send(new GetRentalChargeQuery(invoiceId));
        return Ok(ApiResponse<double?>.Success(result));
    }

    [HttpGet("range")]
    [EndpointSummary("Compute reservation range")]
    public async Task<IActionResult> ComputeReservationRange(int reservationId)
    {
        var result = await mediator.Send(new ComputeReservationRangeCommand(reservationId));
        return Ok(ApiResponse<int>.Success(result, "Computed period (days)"));
    }
}


