using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class FixUserIdGeneration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7589b76b-cdb8-4a34-afd3-858afbcd3420");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85a49010-9f08-4cc3-a733-eccdbb7e299e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccc75934-f33f-479c-bc37-ab70471c272c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd1347bd-abcd-44f4-ae53-c1a25ef1c3fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4120ffa-fe31-4ad7-aff3-0999edaed8f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb1a789-a442-41ad-88b7-5b963515f1d4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7589b76b-cdb8-4a34-afd3-858afbcd3420", null, "Electronics", "ELECTRONICS" },
                    { "85a49010-9f08-4cc3-a733-eccdbb7e299e", null, "HF", "HF" },
                    { "ccc75934-f33f-479c-bc37-ab70471c272c", null, "Transit", "TRANSIT" },
                    { "cd1347bd-abcd-44f4-ae53-c1a25ef1c3fe", null, "VHF", "VHF" },
                    { "d4120ffa-fe31-4ad7-aff3-0999edaed8f8", null, "Manager", "MANAGER" },
                    { "feb1a789-a442-41ad-88b7-5b963515f1d4", null, "Sparepart", "SPAREPART" }
                });
        }
    }
}
