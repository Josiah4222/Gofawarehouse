using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class Iniate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "44224c32-e299-4c5a-8fd3-aa5ed01041ff", null, "Manager", "MANAGER" },
                    { "4aab7a65-bb45-497e-bfc7-5ae2a3197298", null, "Sparepart", "SPAREPART" },
                    { "64ec542e-b8d8-41c8-bc4b-83ea720c2373", null, "Transit", "TRANSIT" },
                    { "74693dd5-c2aa-410b-8134-0755e88a6b05", null, "VHF", "VHF" },
                    { "87aeff69-3631-4365-91d4-68c3fbe66ac9", null, "HF", "HF" },
                    { "af8798e6-d559-4d46-b4d9-f9628b33d74f", null, "Electronics", "ELECTRONICS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44224c32-e299-4c5a-8fd3-aa5ed01041ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4aab7a65-bb45-497e-bfc7-5ae2a3197298");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64ec542e-b8d8-41c8-bc4b-83ea720c2373");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74693dd5-c2aa-410b-8134-0755e88a6b05");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87aeff69-3631-4365-91d4-68c3fbe66ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af8798e6-d559-4d46-b4d9-f9628b33d74f");

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
    }
}
