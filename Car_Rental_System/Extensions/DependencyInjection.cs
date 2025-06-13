using Car_Rental_System.Middlewares;

namespace Car_Rental_System.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerWithAuth();
            services.AddExceptionHandler<AuthorizationExceptionHandler>();
            services.AddExceptionHandler<ValidationExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();

            return services;
        }
    }
}
