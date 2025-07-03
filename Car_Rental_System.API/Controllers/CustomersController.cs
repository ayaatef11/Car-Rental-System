namespace Car_Rental_System.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]

public class CustomersController(IMediator mediator) : ControllerBase
{
    [HttpPost("add")]
    [EndpointSummary("Add a new customer")]
    [ProducesResponseType(typeof(ApiResponse<int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddCustomer([FromBody] AddCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<int>.Success(result, "Customer added successfully"));
    }

    [HttpPut("update")]
    [EndpointSummary("Update existing customer")]
    [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(ApiResponse<bool>.Success(result, "Customer updated successfully"));
    }

    [HttpDelete("{id}")]
    [EndpointSummary("Delete a customer by ID")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var result = await mediator.Send(new DeleteCustomerCommand(id));
        return Ok(ApiResponse.Success("Customer deleted successfully"));
    }

    [HttpGet("all")]
    [EndpointSummary("Get all customers")]
    [ProducesResponseType(typeof(ApiResponse<List<CustomerDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCustomers()
    {
        var result = await mediator.Send(new GetAllCustomersQuery());
        return Ok(ApiResponse<IReadOnlyList<Customer>>.Success(result));
    }

    [HttpGet("{id}")]
    [EndpointSummary("Get customer by ID")]
    [ProducesResponseType(typeof(ApiResponse<CustomerDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCustomer(int id)
    {
        var result = await mediator.Send(new GetCustomerQuery(id));
        return result is not null
            ? Ok(ApiResponse<Customer>.Success(result))
            : NotFound(ApiResponse.Failure("Customer not found"));
    }

    [HttpGet("{id}/rental-history")]
    [EndpointSummary("View customer rental history")]
    [ProducesResponseType(typeof(ApiResponse<CustomerRentalHistoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ViewCustomerRentalHistory(int id)
    {
        var result = await mediator.Send(new ViewCustomerRentalHistoryQuery(id));
        return result is not null
            ? Ok(ApiResponse<ViewCustomerRentalHistoryResult>.Success(result))
            : NotFound(ApiResponse.Failure("Customer or rental history not found"));
    }
}


