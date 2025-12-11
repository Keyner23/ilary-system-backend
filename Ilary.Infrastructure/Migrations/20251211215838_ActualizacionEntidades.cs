using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Coder_CoderId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Companies_CompanyId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CoderId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_CompanyId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CoderId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Roles");

            migrationBuilder.AddColumn<Guid>(
                name: "RolesId",
                table: "Companies",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RolesId",
                table: "Coder",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RolesId",
                table: "Companies",
                column: "RolesId");

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
                name: "FK_Companies_Roles_RolesId",
                table: "Companies",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coder_Roles_RolesId",
                table: "Coder");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Roles_RolesId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RolesId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Coder_RolesId",
                table: "Coder");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Coder");

            migrationBuilder.AddColumn<Guid>(
                name: "CoderId",
                table: "Roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Roles",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CoderId",
                table: "Roles",
                column: "CoderId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CompanyId",
                table: "Roles",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Coder_CoderId",
                table: "Roles",
                column: "CoderId",
                principalTable: "Coder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Companies_CompanyId",
                table: "Roles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
