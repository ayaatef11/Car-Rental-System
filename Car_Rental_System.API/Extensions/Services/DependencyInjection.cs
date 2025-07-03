using Car_Rental_System.API.Middlewares;
using System.Reflection;

namespace Car_Rental_System.API.Extensions.Services;
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
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // or your Application layer
            });
            return services;
        }
    }

