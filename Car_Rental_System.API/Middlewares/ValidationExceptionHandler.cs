using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace Car_Rental_System.API.Middlewares;
public sealed class ValidationExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException validationException)
            return false;
        var problemDetails = new ProblemDetails
        {
            Title = "Validation Failed",
            Detail = "One or more validation error",
            Status = StatusCodes.Status400BadRequest
        };

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

        var context = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = problemDetails,
        };

        return await problemDetailsService.TryWriteAsync(context);
    }
}