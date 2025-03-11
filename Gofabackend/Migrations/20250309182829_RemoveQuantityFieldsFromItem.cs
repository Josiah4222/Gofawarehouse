using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveQuantityFieldsFromItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1bc34ddc-4fbc-4d49-b90e-448787309af6", null, "Electronics", "ELECTRONICS" },
                    { "5ebcefb7-7c91-419b-92c4-32e3988f77dd", null, "Manager", "MANAGER" },
                    { "6ac337c1-6b25-458e-9dce-8c27a6c782ff", null, "VHF", "VHF" },
                    { "a5ad97f0-e1ea-4154-ae17-e5ba74790662", null, "Sparepart", "SPAREPART" },
                    { "b7afca33-8ef5-417f-81cf-620b383c5623", null, "HF", "HF" },
                    { "e5d37ddc-aab2-4e0c-8919-16a38673777f", null, "Transit", "TRANSIT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bc34ddc-4fbc-4d49-b90e-448787309af6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ebcefb7-7c91-419b-92c4-32e3988f77dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac337c1-6b25-458e-9dce-8c27a6c782ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5ad97f0-e1ea-4154-ae17-e5ba74790662");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7afca33-8ef5-417f-81cf-620b383c5623");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5d37ddc-aab2-4e0c-8919-16a38673777f");

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
    }
}
