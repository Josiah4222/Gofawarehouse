using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRolesEnumAndUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0406533d-9ed6-43ba-adc3-9435845b5614", null, "Transit", "TRANSIT" },
                    { "2d954b69-7b99-407d-9df7-f4cb2d914d72", null, "Sparepart", "SPAREPART" },
                    { "575b6b50-2783-4edd-9dd1-bf9f0b2d9a85", null, "HF", "HF" },
                    { "88c31483-7e7c-4d64-ac8d-dfb17521b63e", null, "VHF", "VHF" },
                    { "c2d5df3c-56fc-4445-b7da-432561584e7f", null, "Electronics", "ELECTRONICS" },
                    { "d67d13a9-b645-429a-b9b6-da80728d6fd4", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0406533d-9ed6-43ba-adc3-9435845b5614");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d954b69-7b99-407d-9df7-f4cb2d914d72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "575b6b50-2783-4edd-9dd1-bf9f0b2d9a85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88c31483-7e7c-4d64-ac8d-dfb17521b63e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2d5df3c-56fc-4445-b7da-432561584e7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d67d13a9-b645-429a-b9b6-da80728d6fd4");
        }
    }
}
