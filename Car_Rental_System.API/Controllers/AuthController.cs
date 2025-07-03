namespace Car_Rental_System.API.Controllers;
    [Route("api/[controller]")]
    [ApiController]
public class AuthController(IMediator mediator) : ControllerBase
{

    [HttpPost("register")]
    [EndpointSummary("Register a new user")]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
        success => Ok(ApiResponse<string>.Success(success, "Registration successful! Please check your email to confirm your account.")),
        failure => CustomResults.Problem(failure));
    }

    [HttpPost("login")]
    [EndpointSummary("Login")]
    [ProducesResponseType(typeof(ApiResponse<AuthResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            success => Ok(ApiResponse<AuthResultDto>.Success(success, "Login successful")),
            failure => CustomResults.Problem(failure));
    }

    [HttpPost("refresh")]
    [EndpointSummary("Refresh user token")]
    [ProducesResponseType(typeof(ApiResponse<AuthResultDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenCommand command)
    {
        var result = await mediator.Send(command);
        return result.Match(
            success => Ok(ApiResponse<AuthResultDto>.Success(success, "Token refreshed successfully")),
            failure => CustomResults.Problem(failure));
    }

    [HttpPost("logout")]
    [Authorize]
    [EndpointSummary("Logout")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Logout()
    {
        var result = await mediator.Send(new LogoutCommand());
        return result.Match(
            () => Ok(ApiResponse.Success("Logout successful")),
            failure => CustomResults.Problem(failure));
    }


    [HttpPost("confirm-email")]
    [EndpointSummary("Confirm user email address")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
    {
        var result = await mediator.Send(new ConfirmEmailCommand(userId, token));

        return result.Match(
            success => Ok(ApiResponse.Success("Email confirmed successfully.")),
            failure => CustomResults.Problem(failure));
    }

    [HttpPost("reset-confirmation-email")]
    [EndpointSummary("Generate a new email confirmation link")]
    [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetEmailConfirmation([FromBody] ResetEmailConfirmationCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            success => Ok(ApiResponse<string>.Success(success, "New confirmation email link generated.")),
            failure => CustomResults.Problem(failure));
    }

    [HttpPost("forgot-password")]
    [EndpointSummary("Request password reset link")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            resetLink => Ok(ApiResponse<string>.Success(resetLink, "password reset link sent.")),
            onFailure => CustomResults.Problem(onFailure));
    }


    [HttpPost("reset-password")]
    [EndpointSummary("Reset user password")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromQuery] string userId, [FromQuery] string token, [FromBody] string NewPassword)
    {
        var result = await mediator.Send(new ResetPasswordCommand(userId, token, NewPassword));
        return result.Match(
            () => Ok(ApiResponse.Success("password reset successfully.")),
            onFailure => CustomResults.Problem(onFailure));
    }

    [HttpGet("current-user")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);

        var result = await mediator.Send(new GetCurrentUserQuery(userEmail));
        return result.Match(
            success => Ok(ApiResponse<UserDto>.Success(success,"Gotten Current User successfully.")),
            onFailure => CustomResults.Problem(onFailure));
    }
}


