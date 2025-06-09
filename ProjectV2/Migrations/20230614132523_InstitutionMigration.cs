using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectV2.Migrations
{
    /// <inheritdoc />
    public partial class InstitutionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Institution_InstitutionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "Employee",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Institution_InstitutionId",
                table: "Employee",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "RentalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Institution_InstitutionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "RentalId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "InstitutionId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Institution_InstitutionId",
                table: "Employee",
                column: "InstitutionId",
                principalTable: "Institution",
                principalColumn: "InstitutionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Rental_RentalId",
                table: "Employee",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
