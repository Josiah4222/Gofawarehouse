using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveShelfRequiredConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a0264cb-aeb6-4853-854e-95858d2d84d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f8c0e7-aee7-4a6e-a9e3-75d467c59fba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "869e285a-e615-4a0b-ab9b-eed4bc69fc4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c47dbccd-463d-4f6a-9eb2-a1b0da757725");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5ef26ce-edb8-4822-93f3-2473c38bdbc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1ae0eae-7651-4761-b28b-76903c3e2cd0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "429b5969-bde7-44e3-b851-2503ea285950", null, "Manager", "MANAGER" },
                    { "4e25a0e5-29e8-46db-9a96-ff2f7d8c3e46", null, "VHF", "VHF" },
                    { "9430c8a1-323a-4d1a-a243-3636a6cefe88", null, "Sparepart", "SPAREPART" },
                    { "bae10675-3181-4379-a5c6-f1244bc45808", null, "Transit", "TRANSIT" },
                    { "c8cc32e8-74c4-4ff5-a1f6-3823985759dd", null, "HF", "HF" },
                    { "cc20afb4-d755-47aa-b0c2-04c7a0a0e6b7", null, "Electronics", "ELECTRONICS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "429b5969-bde7-44e3-b851-2503ea285950");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e25a0e5-29e8-46db-9a96-ff2f7d8c3e46");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9430c8a1-323a-4d1a-a243-3636a6cefe88");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae10675-3181-4379-a5c6-f1244bc45808");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8cc32e8-74c4-4ff5-a1f6-3823985759dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc20afb4-d755-47aa-b0c2-04c7a0a0e6b7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a0264cb-aeb6-4853-854e-95858d2d84d6", null, "VHF", "VHF" },
                    { "72f8c0e7-aee7-4a6e-a9e3-75d467c59fba", null, "Transit", "TRANSIT" },
                    { "869e285a-e615-4a0b-ab9b-eed4bc69fc4c", null, "Electronics", "ELECTRONICS" },
                    { "c47dbccd-463d-4f6a-9eb2-a1b0da757725", null, "Sparepart", "SPAREPART" },
                    { "e5ef26ce-edb8-4822-93f3-2473c38bdbc6", null, "HF", "HF" },
                    { "f1ae0eae-7651-4761-b28b-76903c3e2cd0", null, "Manager", "MANAGER" }
                });
        }
    }
}
