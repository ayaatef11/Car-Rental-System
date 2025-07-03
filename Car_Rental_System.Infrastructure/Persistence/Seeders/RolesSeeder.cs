namespace Car_Rental_System.Infrastructure.Persistence.Seeders;
internal class RolesSeeder(AppDbContext dbContext, UserManager<AppUser> userManager) : ISeeder
{
    public async Task SeedAsync()
    {
        if (await dbContext.Database.CanConnectAsync()
            && !await dbContext.Roles.AnyAsync())
        {
            var roles = GetRoles();
            await dbContext.Roles.AddRangeAsync(roles);
            await dbContext.SaveChangesAsync();

            var adminUser = new AppUser
            {
                UserName = "admin",
                Email = "admin@admin.com",
            };
            var createResult = await userManager.CreateAsync(adminUser, "admin123");
            if (createResult.Succeeded)
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
        }
    }

    private List<IdentityRole> GetRoles()
    {
        return new List<IdentityRole>
        {
            new IdentityRole { Name = Roles.User , NormalizedName = Roles.User },
            new IdentityRole { Name = Roles.Admin , NormalizedName = Roles.Admin }
        };
    }
}
