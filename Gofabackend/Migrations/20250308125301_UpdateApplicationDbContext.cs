using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
