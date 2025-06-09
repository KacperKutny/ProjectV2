using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectV2.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RentalId",
                table: "Employee",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RentalId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "Employee");
        }
    }
}
