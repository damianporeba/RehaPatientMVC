using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RehaPatientMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixNameInReferralClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeRefferal",
                table: "referrals",
                newName: "TypeReferal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeReferal",
                table: "referrals",
                newName: "TypeRefferal");
        }
    }
}
