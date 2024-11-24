using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tenant_App.Models.Migrations
{
    public partial class AddDamagesTblToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Damages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: true),
                    IPAddress = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    PropertyId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DamageImagePath = table.Column<string>(nullable: true),
                    DamageType = table.Column<string>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    status = table.Column<string>(nullable: true),
                    Priority = table.Column<string>(nullable: true),
                    AdminComment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Damages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Damages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Damages_UserId",
                table: "Damages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Damages");
        }
    }
}
