using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class removedlocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1684ea7d-c2b7-4f81-abfa-f4bd24665d0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a7dae6c-d20d-4e55-9488-431a9d639539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bc9a464-9853-4832-8d10-963e0913240e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae9c67ba-ed95-4c41-9a7a-891efba4e1f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba580757-1444-466d-a8d3-8b1acbed2a37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d61e413f-e55f-4beb-b427-8389d0bd15a2");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Items");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1684ea7d-c2b7-4f81-abfa-f4bd24665d0a", null, "VHF", "VHF" },
                    { "3a7dae6c-d20d-4e55-9488-431a9d639539", null, "HF", "HF" },
                    { "5bc9a464-9853-4832-8d10-963e0913240e", null, "Sparepart", "SPAREPART" },
                    { "ae9c67ba-ed95-4c41-9a7a-891efba4e1f8", null, "Transit", "TRANSIT" },
                    { "ba580757-1444-466d-a8d3-8b1acbed2a37", null, "Manager", "MANAGER" },
                    { "d61e413f-e55f-4beb-b427-8389d0bd15a2", null, "Electronics", "ELECTRONICS" }
                });
        }
    }
}
