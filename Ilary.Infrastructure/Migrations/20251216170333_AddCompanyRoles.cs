using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Roles_RolesId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RolesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CompanyRoles",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRoles", x => new { x.CompanyId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_CompanyRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyRoles_RolesId",
                table: "CompanyRoles",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "RolesId",
                table: "Companies",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RolesId",
                table: "Companies",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Roles_RolesId",
                table: "Companies",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
