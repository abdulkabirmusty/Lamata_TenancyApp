using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class UpdateCoopearteTenantTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CACRegNo",
                table: "CooperateTenants",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConsent",
                table: "CooperateTenants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TIN",
                table: "CooperateTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CACRegNo",
                table: "CooperateTenants");

            migrationBuilder.DropColumn(
                name: "IsConsent",
                table: "CooperateTenants");

            migrationBuilder.DropColumn(
                name: "TIN",
                table: "CooperateTenants");
        }
    }
}
