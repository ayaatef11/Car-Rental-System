using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Car_Rental_System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Invoices_InvoiceId",
                table: "Reservation");

            migrationBuilder.DropIndex(
                name: "IX_Reservation_InvoiceId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Reservation");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Reservation_ReservationId",
                table: "Invoices",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Reservation_ReservationId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_ReservationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_InvoiceId",
                table: "Reservation",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Invoices_InvoiceId",
                table: "Reservation",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
