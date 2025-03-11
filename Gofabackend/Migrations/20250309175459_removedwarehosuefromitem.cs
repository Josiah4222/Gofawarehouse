using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class removedwarehosuefromitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1591a1f2-ab03-44d6-99ac-c934c1018d57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216ffc34-7a16-4b8d-b7ab-dab0d377f57d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45623c3c-1e36-4e0b-bd31-566f58cabe89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b25b9b05-4059-4197-a669-71685eb3ce2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd669fd3-0c9c-45b0-9a4a-013b10115088");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0aff79c-fbe1-45d8-85b4-dfe10c57c0d4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1684ea7d-c2b7-4f81-abfa-f4bd24665d0a", null, "VHF", "VHF" },
                    { "3a7dae6c-d20d-4e55-9488-431a9d639539", null, "HF", "HF" },
                    { "5bc9a464-9853-4832-8d10-963e0913240e", null, "Sparepart", "SPAREPART" },
                    { "ae9c67ba-ed95-4c41-9a7a-891efba4e1f8", null, "Transit", "TRANSIT" },
                    { "ba580757-1444-466d-a8d3-8b1acbed2a37", null, "Manager", "MANAGER" },
                    { "d61e413f-e55f-4beb-b427-8389d0bd15a2", null, "Electronics", "ELECTRONICS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684ea7d-c2b7-4f81-abfa-f4bd24665d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a7dae6c-d20d-4e55-9488-431a9d639539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc9a464-9853-4832-8d10-963e0913240e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9c67ba-ed95-4c41-9a7a-891efba4e1f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba580757-1444-466d-a8d3-8b1acbed2a37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d61e413f-e55f-4beb-b427-8389d0bd15a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1591a1f2-ab03-44d6-99ac-c934c1018d57", null, "Electronics", "ELECTRONICS" },
                    { "216ffc34-7a16-4b8d-b7ab-dab0d377f57d", null, "Transit", "TRANSIT" },
                    { "45623c3c-1e36-4e0b-bd31-566f58cabe89", null, "Manager", "MANAGER" },
                    { "b25b9b05-4059-4197-a669-71685eb3ce2c", null, "Sparepart", "SPAREPART" },
                    { "bd669fd3-0c9c-45b0-9a4a-013b10115088", null, "VHF", "VHF" },
                    { "d0aff79c-fbe1-45d8-85b4-dfe10c57c0d4", null, "HF", "HF" }
                });
        }
    }
}
