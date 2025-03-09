using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class AddWarehouseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "068bd2f8-18c3-45f8-a448-34d623478f20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ef84045-9cfb-434c-8785-9ddb0b426b56");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b24ca72-4e66-4cd1-82ce-573a3460560d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "762bb67d-e5b8-4cc8-ae69-d87e6eafae51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5713009-7f3e-4aff-b0dd-59da0eea6b9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead19a56-ceaa-46eb-bc08-cd4a7c368d2c");

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a4a0986-f25d-40ea-ad5c-29bdba5c9b58", null, "Manager", "MANAGER" },
                    { "0c223bff-3269-483c-ab06-9e8c3576176b", null, "Electronics", "ELECTRONICS" },
                    { "183fc6d5-1738-452e-8dbd-196a9b04b72a", null, "HF", "HF" },
                    { "635c90ac-433b-4c25-a6ac-667b6c3076eb", null, "Transit", "TRANSIT" },
                    { "b016ad38-436f-41f4-ac84-d9d46ee7909f", null, "Sparepart", "SPAREPART" },
                    { "f4a13fb2-f1c7-4de8-9d08-b35f14839b59", null, "VHF", "VHF" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4a0986-f25d-40ea-ad5c-29bdba5c9b58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c223bff-3269-483c-ab06-9e8c3576176b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "183fc6d5-1738-452e-8dbd-196a9b04b72a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "635c90ac-433b-4c25-a6ac-667b6c3076eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b016ad38-436f-41f4-ac84-d9d46ee7909f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a13fb2-f1c7-4de8-9d08-b35f14839b59");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "068bd2f8-18c3-45f8-a448-34d623478f20", null, "VHF", "VHF" },
                    { "4ef84045-9cfb-434c-8785-9ddb0b426b56", null, "Manager", "MANAGER" },
                    { "6b24ca72-4e66-4cd1-82ce-573a3460560d", null, "Electronics", "ELECTRONICS" },
                    { "762bb67d-e5b8-4cc8-ae69-d87e6eafae51", null, "Sparepart", "SPAREPART" },
                    { "a5713009-7f3e-4aff-b0dd-59da0eea6b9d", null, "HF", "HF" },
                    { "ead19a56-ceaa-46eb-bc08-cd4a7c368d2c", null, "Transit", "TRANSIT" }
                });
        }
    }
}
