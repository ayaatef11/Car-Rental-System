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
        return Ok(ApiResponse<bool>.Success(result, "Car updated successfully"));
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Delete a car by ID")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCar(int id)
    {
        var result = await mediator.Send(new DeleteCarCommand(id));
        return Ok(ApiResponse.Success("Car deleted successfully"));
    }

    [HttpPost("rent")]
    [EndpointSummary("Rent a car")]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RentCar([FromBody] RentCarCommand command)
    {
        var result = await mediator.Send(command);
        return result.Match(
            success => Ok(ApiResponse<string>.Success(success, "Car rented successfully")),
            failure => CustomResults.Problem(failure)
        );
    }

    [HttpPost("return")]
    [EndpointSummary("Return a rented car")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> ReturnCar([FromBody] ReturnCarCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse.Success("Car returned successfully"));
    }

    [HttpGet("all")]
    [EndpointSummary("Get all cars")]
    [ProducesResponseType(typeof(ApiResponse<List<CarDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCars()
    {
        var result = await mediator.Send(new GetAllCarsQuery());
        return Ok(ApiResponse<List<CarDto>>.Success(result));
    }

    [HttpGet("available")]
    [EndpointSummary("Get all available cars")]
    [ProducesResponseType(typeof(ApiResponse<List<CarDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAvailableCars()
    {
        var result = await mediator.Send(new GetAvailableCarsQuery());
        return Ok(ApiResponse<List<CarDto>>.Success(result));
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get car by ID")]
    [ProducesResponseType(typeof(ApiResponse<CarDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCarById(int id)
    {
        var result = await mediator.Send(new GetCarByIdQuery(id));
        return result is not null
            ? Ok(ApiResponse<CarDto>.Success(result))
            : NotFound(ApiResponse.Failure("Car not found"));
    }
}


