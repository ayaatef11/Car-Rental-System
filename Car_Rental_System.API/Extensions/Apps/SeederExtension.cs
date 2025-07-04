﻿using Car_Rental_System.Infrastructure.Persistence.Seeders;

namespace Car_Rental_System.API.Extensions.Apps;
public static class SeederExtensions
{
    public static async Task SeedDataAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();

        var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppSeeder>>();
        var seeder = scope.ServiceProvider.GetRequiredService<AppSeeder>();

        try
        {
            logger.LogInformation("Starting database seeding...");
            await seeder.SeedAsync();
            logger.LogInformation("Database seeding completed.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during database seeding.");
            throw;
        }
    }
}
