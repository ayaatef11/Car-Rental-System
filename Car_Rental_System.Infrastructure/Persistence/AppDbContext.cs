using Car_Rental_System.Domain.Constants;
using Car_Rental_System.Domain.Entities;
using Car_Rental_System.Infrastructure.Services.Signalr;
using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Infrastructure.Persistence;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Reservation> RentalAgreements { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<NotificationPreferences> NotificationPreferences { get; internal set; }
    public DbSet<Role> Roles { get; internal set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}

