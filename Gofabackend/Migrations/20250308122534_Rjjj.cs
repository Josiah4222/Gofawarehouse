using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class Rjjj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01e076df-dab8-4323-b7d0-f2819e1aa081");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "224dd0de-3a7a-4bf1-becf-04fd39633dd0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cc9716f-914c-4692-b8db-22fa312f6756");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b20a39e-411b-418a-a55f-cd7d6be14a13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9aeb2b80-af7c-4381-bc7b-d40386551092");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a916dc7e-5844-40dc-b66a-d5a891ee2063");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "01e076df-dab8-4323-b7d0-f2819e1aa081", null, "VHF", "VHF" },
                    { "224dd0de-3a7a-4bf1-becf-04fd39633dd0", null, "Electronics", "ELECTRONICS" },
                    { "3cc9716f-914c-4692-b8db-22fa312f6756", null, "Sparepart", "SPAREPART" },
                    { "6b20a39e-411b-418a-a55f-cd7d6be14a13", null, "HF", "HF" },
                    { "9aeb2b80-af7c-4381-bc7b-d40386551092", null, "Transit", "TRANSIT" },
                    { "a916dc7e-5844-40dc-b66a-d5a891ee2063", null, "Manager", "MANAGER" }
                });
        }
    }
}
