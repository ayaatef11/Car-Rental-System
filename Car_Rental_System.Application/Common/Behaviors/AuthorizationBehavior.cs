using MediatR;
using Car_Rental_System.Application.Common.Interfaces;
namespace Car_Rental_System.Application.Common.Behaviors;


public class AuthorizationBehavior<TRequest, TResponse>(IAuthorAuthorizationService _authorAuthService, IUnitOfWork _unitOfWork) : IPipelineBehavior<TRequest, TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (request is IRequireAuthorAuthorization authRequest)
        {
            var authorized = await _authorAuthService.IsAuthorOwnerOrAdminAsync(authRequest.AuthorId);
            if (!authorized)
                throw new UnauthorizedAccessException();
        }

        return await next();
    }
}


