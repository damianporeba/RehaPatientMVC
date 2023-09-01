using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehaPatientMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patients_medics_MedicId",
                table: "patients");

            migrationBuilder.DropIndex(
                name: "IX_patients_MedicId",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "MedicId",
                table: "patients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicId",
                table: "patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_patients_MedicId",
                table: "patients",
                column: "MedicId");

            migrationBuilder.AddForeignKey(
                name: "FK_patients_medics_MedicId",
                table: "patients",
                column: "MedicId",
                principalTable: "medics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
