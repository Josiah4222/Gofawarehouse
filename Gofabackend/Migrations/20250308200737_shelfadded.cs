using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class shelfadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ca25399-24a0-4de6-8efc-fc94fb6b2349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93f20a11-df52-4e17-9586-860cf9d8d21f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab2c30af-f70e-4341-83c6-fa0268dc00ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c81448bf-740f-4581-9ee2-c0982e2b698a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6260c0b-8872-409a-927d-d919205be1ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9396015-c2e4-4317-9024-9f6e1c0edf51");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8ca25399-24a0-4de6-8efc-fc94fb6b2349", null, "Transit", "TRANSIT" },
                    { "93f20a11-df52-4e17-9586-860cf9d8d21f", null, "Electronics", "ELECTRONICS" },
                    { "ab2c30af-f70e-4341-83c6-fa0268dc00ba", null, "HF", "HF" },
                    { "c81448bf-740f-4581-9ee2-c0982e2b698a", null, "Sparepart", "SPAREPART" },
                    { "f6260c0b-8872-409a-927d-d919205be1ef", null, "VHF", "VHF" },
                    { "f9396015-c2e4-4317-9024-9f6e1c0edf51", null, "Manager", "MANAGER" }
                });
        }
    }
}
