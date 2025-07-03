namespace Car_Rental_System.Infrastructure.Configurations;
public static class HangfireJobsConfigurator
{
    public static void ConfigureRecurringJobs()
    {
        RecurringJob.AddOrUpdate<RefreshTokenCleanupJob>(
            "refresh-token-cleanup",
            job => job.RunAsync(),
            Cron.Daily);
    }
}