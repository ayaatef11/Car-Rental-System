using Car_Rental_System.Models;

using Microsoft.EntityFrameworkCore;

namespace Car_Rental_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CarRentalSystem>CarRentalSystems { get; set; }
        public DbSet<Company>Companies { get; set; }
        public DbSet<Date>Dates { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Person>People { get; set; }
        public DbSet<RentalAgreement> RentalAgreements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.StartDate)
            //    .WithMany()
            //    .HasForeignKey(r => r.Id)
            //    .OnDelete(DeleteBehavior.SetNull);  // No automatic deletion

            //modelBuilder.Entity<Reservation>()
            //    .HasOne(r => r.EndDate)
            //    .WithMany()
            //    .HasForeignKey(r => r.Id)
            //    .OnDelete(DeleteBehavior.SetNull);  // No automatic deletion
        }

    }

}
