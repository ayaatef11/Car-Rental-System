using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Rental_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class StatusReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
