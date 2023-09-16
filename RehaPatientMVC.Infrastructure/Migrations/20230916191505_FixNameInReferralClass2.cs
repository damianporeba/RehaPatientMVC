using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehaPatientMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNameInReferralClass2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeReferal",
                table: "referrals",
                newName: "TypeReferral");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeReferral",
                table: "referrals",
                newName: "TypeReferal");
        }
    }
}
