using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTempaltes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsPaid", "Keywords", "Name", "Palette", "Themes", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A fine CV for a sauve and professional look", false, "[\"Professional\",\"Portfolio\",\"Modern\"]", "Web Developer CV", "[\"#000\",\"#111\"]", "[\"Professional\",\"Upbright\"]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A fine CV for a automated engineer like youself", true, "[\"Professional\",\"Portfolio\",\"Modern\"]", "AI Developer CV", "[\"#000111\",\"#111000\"]", "[\"Professional\",\"Upbright\"]", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
