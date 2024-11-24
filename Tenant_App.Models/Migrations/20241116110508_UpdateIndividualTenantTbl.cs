using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class UpdateIndividualTenantTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsConsent",
                table: "IndividualTenants",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsConsent",
                table: "IndividualTenants");
        }
    }
}
