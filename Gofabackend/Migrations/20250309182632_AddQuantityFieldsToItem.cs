using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityFieldsToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00f87397-38e2-4621-bed5-34994a1af499");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ad4abb3-1717-4d4d-9e6f-71d573df012e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "478f474b-88a9-4f23-aac2-fafb59798355");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84850dee-6e77-46b4-85db-8f35c3757056");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b2b7eebf-4a4a-4afb-bd49-0d8bec8ee50e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f02aef8d-0b3e-444c-a338-82dbf8cb4694");

            migrationBuilder.AddColumn<int>(
                name: "AddedQuantity",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WithdrawnQuantity",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "41fe3991-9ac5-40dc-b831-5ea73913817f", null, "Transit", "TRANSIT" },
                    { "6c2c4d6e-8c77-41f1-99fa-6e8b1fe6409b", null, "VHF", "VHF" },
                    { "9e9f91d1-c084-4173-bc4d-1e111eb1628c", null, "Manager", "MANAGER" },
                    { "a626960b-eacf-4efb-bd5a-e1ffac1cc8ad", null, "HF", "HF" },
                    { "af669a10-1541-4a39-a621-ab43b099ff0b", null, "Electronics", "ELECTRONICS" },
                    { "d5172c31-c7cd-4845-9ec2-edfafc83e52a", null, "Sparepart", "SPAREPART" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "41fe3991-9ac5-40dc-b831-5ea73913817f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c2c4d6e-8c77-41f1-99fa-6e8b1fe6409b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e9f91d1-c084-4173-bc4d-1e111eb1628c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a626960b-eacf-4efb-bd5a-e1ffac1cc8ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af669a10-1541-4a39-a621-ab43b099ff0b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5172c31-c7cd-4845-9ec2-edfafc83e52a");

            migrationBuilder.DropColumn(
                name: "AddedQuantity",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "WithdrawnQuantity",
                table: "Items");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00f87397-38e2-4621-bed5-34994a1af499", null, "Manager", "MANAGER" },
                    { "3ad4abb3-1717-4d4d-9e6f-71d573df012e", null, "HF", "HF" },
                    { "478f474b-88a9-4f23-aac2-fafb59798355", null, "VHF", "VHF" },
                    { "84850dee-6e77-46b4-85db-8f35c3757056", null, "Sparepart", "SPAREPART" },
                    { "b2b7eebf-4a4a-4afb-bd49-0d8bec8ee50e", null, "Transit", "TRANSIT" },
                    { "f02aef8d-0b3e-444c-a338-82dbf8cb4694", null, "Electronics", "ELECTRONICS" }
                });
        }
    }
}
