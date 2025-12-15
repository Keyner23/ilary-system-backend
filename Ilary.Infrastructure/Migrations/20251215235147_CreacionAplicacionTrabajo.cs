using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreacionAplicacionTrabajo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Companies_CompanyId",
                table: "JobApplications");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "JobApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoderId",
                table: "JobApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId1",
                table: "JobApplications",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications",
                column: "CoderId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CompanyId1",
                table: "JobApplications",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Coder_CoderId",
                table: "JobApplications",
                column: "CoderId",
                principalTable: "Coder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Companies_CompanyId",
                table: "JobApplications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Companies_CompanyId1",
                table: "JobApplications",
                column: "CompanyId1",
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

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Companies_CompanyId1",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CoderId",
                table: "JobApplications");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_CompanyId1",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CoderId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "JobApplications");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "JobApplications",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_Companies_CompanyId",
                table: "JobApplications",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
