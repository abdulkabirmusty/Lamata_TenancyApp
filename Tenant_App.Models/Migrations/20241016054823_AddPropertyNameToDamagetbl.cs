using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class AddPropertyNameToDamagetbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "Damages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "Damages");
        }
    }
}
