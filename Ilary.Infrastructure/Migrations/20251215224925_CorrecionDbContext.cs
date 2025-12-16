using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coder_Roles_RolesId",
                table: "Coder");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Coder_CoderId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_Coder_RolesId",
                table: "Coder");

            migrationBuilder.DropColumn(
                name: "CoderId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Coder");

            migrationBuilder.CreateTable(
                name: "CoderRoles",
                columns: table => new
                {
                    CodersId = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoderRoles", x => new { x.CodersId, x.RolesId });
                    table.ForeignKey(
                        name: "FK_CoderRoles_Coder_CodersId",
                        column: x => x.CodersId,
                        principalTable: "Coder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoderRoles_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoderRoles_RolesId",
                table: "CoderRoles",
                column: "RolesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoderRoles");

            migrationBuilder.AddColumn<Guid>(
                name: "CoderId",
                table: "JobApplications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RolesId",
                table: "Coder",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications",
                column: "CoderId");

            migrationBuilder.CreateIndex(
                name: "IX_Coder_RolesId",
                table: "Coder",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coder_Roles_RolesId",
                table: "Coder",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Coder_CoderId",
                table: "JobApplications",
                column: "CoderId",
                principalTable: "Coder",
                principalColumn: "Id");
        }
    }
}
