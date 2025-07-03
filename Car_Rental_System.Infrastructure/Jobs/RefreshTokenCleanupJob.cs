namespace Car_Rental_System.Infrastructure.Jobs;
internal class RefreshTokenCleanupJob(AppDbContext context)
{
    public async Task RunAsync()
    {
        var tokens = await context.RefreshTokens
            .Where(x => (x.IsUsed || x.IsRevoked) && x.ExpiryDate < DateTime.UtcNow)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }
}

