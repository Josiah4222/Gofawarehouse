using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class editedshelf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e0c66d3-3cce-4cf8-988a-f7fa5848977b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41970550-4416-4fd1-9749-c9c9f2ab9871");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "461de55f-955a-44cd-9fbe-79f1a3c39d97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e81dda3-a1ea-45fd-9029-5c85cdfe4d48");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c9cf91a-eb15-47ad-a310-0911611bd7ec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc04b744-cd87-482d-95a6-0ccd3cd94f97");

            migrationBuilder.AddColumn<string>(
                name: "WarehouseName",
                table: "Shelf",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f01e220-6dca-4082-ad39-b67b036dabd6", null, "Manager", "MANAGER" },
                    { "806d2b33-b0a8-4fdd-8bb7-e23a8182eeb6", null, "Transit", "TRANSIT" },
                    { "87476fb1-581a-424f-a1de-352f4b36f265", null, "HF", "HF" },
                    { "88738ab8-dd7a-44c9-92ed-46ee107d7a11", null, "VHF", "VHF" },
                    { "af1b28f7-c8c4-45f5-8c53-7a293b28ae52", null, "Sparepart", "SPAREPART" },
                    { "fbb73d14-53ab-4a0b-866d-e308581db678", null, "Electronics", "ELECTRONICS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f01e220-6dca-4082-ad39-b67b036dabd6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "806d2b33-b0a8-4fdd-8bb7-e23a8182eeb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87476fb1-581a-424f-a1de-352f4b36f265");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88738ab8-dd7a-44c9-92ed-46ee107d7a11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af1b28f7-c8c4-45f5-8c53-7a293b28ae52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fbb73d14-53ab-4a0b-866d-e308581db678");

            migrationBuilder.DropColumn(
                name: "WarehouseName",
                table: "Shelf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3e0c66d3-3cce-4cf8-988a-f7fa5848977b", null, "HF", "HF" },
                    { "41970550-4416-4fd1-9749-c9c9f2ab9871", null, "Electronics", "ELECTRONICS" },
                    { "461de55f-955a-44cd-9fbe-79f1a3c39d97", null, "VHF", "VHF" },
                    { "4e81dda3-a1ea-45fd-9029-5c85cdfe4d48", null, "Sparepart", "SPAREPART" },
                    { "5c9cf91a-eb15-47ad-a310-0911611bd7ec", null, "Manager", "MANAGER" },
                    { "cc04b744-cd87-482d-95a6-0ccd3cd94f97", null, "Transit", "TRANSIT" }
                });
        }
    }
}
