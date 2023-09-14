using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehaPatientMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationReferraltoMedic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RefferalId",
                table: "referrals",
                newName: "MedicId");

            migrationBuilder.CreateIndex(
                name: "IX_referrals_MedicId",
                table: "referrals",
                column: "MedicId");

            migrationBuilder.AddForeignKey(
                name: "FK_referrals_medics_MedicId",
                table: "referrals",
                column: "MedicId",
                principalTable: "medics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_referrals_medics_MedicId",
                table: "referrals");

            migrationBuilder.DropIndex(
                name: "IX_referrals_MedicId",
                table: "referrals");

            migrationBuilder.RenameColumn(
                name: "MedicId",
                table: "referrals",
                newName: "RefferalId");
        }
    }
}
