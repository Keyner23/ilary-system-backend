using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEntidadesJobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coder_JobApplications_JobApplicationId",
                table: "Coder");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_JobApplications_JobApplicationId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_JobApplicationId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Coder_JobApplicationId",
                table: "Coder");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "Coder");

            migrationBuilder.AddColumn<Guid>(
                name: "CoderId",
                table: "JobApplications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "JobApplications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications",
                column: "CoderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CompanyId",
                table: "JobApplications",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Coder_CoderId",
                table: "JobApplications",
                column: "CoderId",
                principalTable: "Coder",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Companies_CompanyId",
                table: "JobApplications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Coder_CoderId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Companies_CompanyId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CompanyId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CoderId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobApplications");

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationId",
                table: "Companies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationId",
                table: "Coder",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_JobApplicationId",
                table: "Companies",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Coder_JobApplicationId",
                table: "Coder",
                column: "JobApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coder_JobApplications_JobApplicationId",
                table: "Coder",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_JobApplications_JobApplicationId",
                table: "Companies",
                column: "JobApplicationId",
                principalTable: "JobApplications",
                principalColumn: "Id");
        }
    }
}
