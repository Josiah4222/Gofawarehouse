using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c417fd9-f99e-4002-ac03-64900f2c447f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a4b7eba-7336-483f-a093-193f84089279");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e5dc35c-07c1-4d1b-8150-158be9e6ad85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99081914-f1a4-4f6d-b92a-e86c6b13a1ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba779a98-9375-4082-82ce-02e845bde349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafe8fe2-dd9d-4de6-b339-d8e1bc302195");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "0c417fd9-f99e-4002-ac03-64900f2c447f", null, "VHF", "VHF" },
                    { "3a4b7eba-7336-483f-a093-193f84089279", null, "Manager", "MANAGER" },
                    { "3e5dc35c-07c1-4d1b-8150-158be9e6ad85", null, "HF", "HF" },
                    { "99081914-f1a4-4f6d-b92a-e86c6b13a1ba", null, "Transit", "TRANSIT" },
                    { "ba779a98-9375-4082-82ce-02e845bde349", null, "Electronics", "ELECTRONICS" },
                    { "bafe8fe2-dd9d-4de6-b339-d8e1bc302195", null, "Sparepart", "SPAREPART" }
                });
        }
    }
}
