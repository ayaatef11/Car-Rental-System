using Car_Rental_System.Infrastructure.Persistence.Seeders;
using System.Runtime.CompilerServices;

namespace Car_Rental_System.API.Extensions.Services;
    public static class ConfigurationExtension
    {
        public static IServiceCollection AddConfigurationClasses(this IServiceCollection services)
        {
            services.AddScoped<AppSeeder>();
            return services;
        }
    }

