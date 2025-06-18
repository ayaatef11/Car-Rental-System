
using Microsoft.AspNetCore.Authorization;

namespace Car_Rental_System.API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class UserFollowsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("follow")]
        [Authorize]
        [EndpointSummary("Follow a user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Follow([FromBody] FollowUserCommand command)
        {
            var result = await mediator.Send(command);

            return result.Match(
                () => Ok(ApiResponse.Success("User followed successfully.")),
                failure => CustomResults.Problem(failure));
        }

        [HttpPost("unfollow")]
        [Authorize]
        [EndpointSummary("Follow a user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Unfollow([FromBody] UnfollowUserCommand command)
        {
            var result = await mediator.Send(command);

            return result.Match(
                () => Ok(ApiResponse.Success("User unfollowed successfully.")),
                failure => CustomResults.Problem(failure));
        }

        [HttpGet("followers")]
        [Authorize]
        [EndpointSummary("Get followers of a user")]
        [ProducesResponseType(typeof(PagedResult<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetFollowers(int? pageNumber, int? pageSize)
        {
            var result = await mediator.Send(new GetFollowersQuery(pageNumber, pageSize));

            return result.Match(
                followers => Ok(followers),
                failure => CustomResults.Problem(failure));
        }

        [HttpGet("following")]
        [Authorize]
        [EndpointSummary("Get following of a user")]
        [ProducesResponseType(typeof(PagedResult<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetFollowing(int? pageNumber, int? pageSize)
        {
            var result = await mediator.Send(new GetFollowingQuery(pageNumber, pageSize));

            return result.Match(
              following => Ok(following),
              failure => CustomResults.Problem(failure));
        }

    }

