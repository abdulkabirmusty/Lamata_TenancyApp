using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class UpdatePropertyTblInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "PropertyTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "PropertyTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dimension",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Properties",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "PropertyTenants");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "PropertyTenants");

            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Properties");
        }
    }
}
