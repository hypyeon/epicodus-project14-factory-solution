using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Factory.Migrations
{
    public partial class EditLicenseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerLicenses_Licneses_LicenseId",
                table: "EngineerLicenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licneses",
                table: "Licneses");

            migrationBuilder.RenameTable(
                name: "Licneses",
                newName: "Licenses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerLicenses_Licenses_LicenseId",
                table: "EngineerLicenses",
                column: "LicenseId",
                principalTable: "Licenses",
                principalColumn: "LicenseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineerLicenses_Licenses_LicenseId",
                table: "EngineerLicenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Licenses",
                table: "Licenses");

            migrationBuilder.RenameTable(
                name: "Licenses",
                newName: "Licneses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Licneses",
                table: "Licneses",
                column: "LicenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineerLicenses_Licneses_LicenseId",
                table: "EngineerLicenses",
                column: "LicenseId",
                principalTable: "Licneses",
                principalColumn: "LicenseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
