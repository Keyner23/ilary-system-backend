using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ilary.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Clean up existing JobApplications before adding StatusId
            migrationBuilder.Sql("DELETE FROM \"JobApplications\";");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "JobApplications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationStatuses",
                columns: new[] { "Id", "Color", "Created", "Description", "Name", "Order" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), "info", new DateTime(2025, 12, 16, 21, 4, 34, 797, DateTimeKind.Utc).AddTicks(5549), "Postulación enviada", "Enviada", 1 },
                    { new Guid("00000000-0000-0000-0000-000000000002"), "warning", new DateTime(2025, 12, 16, 21, 4, 34, 797, DateTimeKind.Utc).AddTicks(5556), "La empresa está revisando tu perfil", "En Revisión", 2 },
                    { new Guid("00000000-0000-0000-0000-000000000003"), "primary", new DateTime(2025, 12, 16, 21, 4, 34, 797, DateTimeKind.Utc).AddTicks(5559), "Programado para entrevista", "Entrevista", 3 },
                    { new Guid("00000000-0000-0000-0000-000000000004"), "success", new DateTime(2025, 12, 16, 21, 4, 34, 797, DateTimeKind.Utc).AddTicks(5563), "¡Felicitaciones! Fuiste seleccionado", "Aceptada", 4 },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "danger", new DateTime(2025, 12, 16, 21, 4, 34, 797, DateTimeKind.Utc).AddTicks(5568), "No fuiste seleccionado en esta ocasión", "Rechazada", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_StatusId",
                table: "JobApplications",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications",
                column: "StatusId",
                principalTable: "ApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_ApplicationStatuses_StatusId",
                table: "JobApplications");

            migrationBuilder.DropTable(
                name: "ApplicationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_JobApplications_StatusId",
                table: "JobApplications");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "JobApplications");
        }
    }
}
