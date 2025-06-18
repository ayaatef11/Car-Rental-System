using Car_Rental_System.Domain.Constants;
using Car_Rental_System.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Car_Rental_System.Infrastructure.Persistence.Seeders;

internal class RolesSeeder(AppDbContext dbContext, UserManager<User> userManager) : ISeeder
{
    public async Task SeedAsync()
    {
        if (await dbContext.Database.CanConnectAsync()
            && !await dbContext.Roles.AnyAsync())
        {
            var roles = GetRoles();
            await dbContext.Roles.AddRangeAsync(roles);
            await dbContext.SaveChangesAsync();

            var adminUser = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
            };
            var createResult = await userManager.CreateAsync(adminUser, "admin123");
            if (createResult.Succeeded)
                await userManager.AddToRoleAsync(adminUser, Roles.Admin.ToString());
        }
    }

    private List<Role> GetRoles()
    {
        return new List<Role>
        {
            new Role { Name = Roles.User.ToString() , NormalizedName = Roles.User.ToString() },
            new Role { Name = Roles.Admin.ToString() , NormalizedName = Roles.Admin.ToString() }
        };
    }
}
