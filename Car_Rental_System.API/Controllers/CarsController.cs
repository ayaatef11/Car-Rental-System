namespace Car_Rental_System.API.Controllers;
    [Route("api/[controller]")]
    [ApiController]

public class CarsController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [EndpointSummary("Add a new car")]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCar([FromBody] AddCarCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<int>.Success(result, "Car added successfully"));
    }

    [HttpPut("update")]
    [EndpointSummary("Update an existing car")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCar([FromBody] UpdateCarCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<object?>.Success(result, "Car updated successfully"));
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Delete a car by ID")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await mediator.Send(new DeleteCarCommand(id));
        return Ok(ApiResponse.Success("Car deleted successfully"));
    }


    [HttpPost("check-available")]
    [EndpointSummary("Check Car Availability")]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CheckAvailability([FromBody] CheckCarAvailabilityCommand command)
    {
        var result = await mediator.Send(command);
        return result.Match(
            success => Ok(ApiResponse<bool>.Success(success, "Car is available")),
                    failure => CustomResults.Problem(failure));
    }

    [HttpGet("all")]
    [EndpointSummary("Get all cars")]
    [ProducesResponseType(typeof(ApiResponse<List<CarDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCars()
    {
        var result = await mediator.Send(new GetAllCarsQuery());
        return Ok(ApiResponse<IEnumerable<Car>?>.Success(result));
    }

    [HttpGet("available")]
    [EndpointSummary("Get all available cars")]
    [ProducesResponseType(typeof(ApiResponse<List<CarDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableCars(DateTime startDate,DateTime endDate)
    {
        var result = await mediator.Send(new GetAvailableCarsQuery(startDate,endDate));
        return Ok(ApiResponse<List<Car>?>.Success(result));
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get car by ID")]
    [ProducesResponseType(typeof(ApiResponse<CarDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCarById(int id)
    {
        var result = await mediator.Send(new GetCarByIdQuery(id));
        return result is not null
            ? Ok(ApiResponse<Car?>.Success(result))
            : NotFound(ApiResponse.Failure("Car not found"));
    }
}


