using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class AddBankDetailToIndTenantTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "IndividualTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAccountNo",
                table: "IndividualTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "IndividualTenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeOfBusiness",
                table: "IndividualTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "IndividualTenants");

            migrationBuilder.DropColumn(
                name: "BankAccountNo",
                table: "IndividualTenants");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "IndividualTenants");

            migrationBuilder.DropColumn(
                name: "TypeOfBusiness",
                table: "IndividualTenants");
        }
    }
}
