using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class Addedstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ddab46b-6bcb-4257-a142-329fcdcaba44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13399dd3-b470-4b42-bd60-2f81017679bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "460d2a0e-8960-4646-8b00-a669ee0f4bad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54e5ceb9-5ac6-46f3-ad30-9b815a682718");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8173a1b7-1380-4a8e-82aa-8e67d3ce2cd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e7c4b2fd-88be-47a6-bc34-2c577cc5d4af");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Model1",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Model1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ddab46b-6bcb-4257-a142-329fcdcaba44", null, "Transit", "TRANSIT" },
                    { "13399dd3-b470-4b42-bd60-2f81017679bc", null, "Electronics", "ELECTRONICS" },
                    { "460d2a0e-8960-4646-8b00-a669ee0f4bad", null, "Manager", "MANAGER" },
                    { "54e5ceb9-5ac6-46f3-ad30-9b815a682718", null, "Sparepart", "SPAREPART" },
                    { "8173a1b7-1380-4a8e-82aa-8e67d3ce2cd5", null, "VHF", "VHF" },
                    { "e7c4b2fd-88be-47a6-bc34-2c577cc5d4af", null, "HF", "HF" }
                });
        }
    }
}
