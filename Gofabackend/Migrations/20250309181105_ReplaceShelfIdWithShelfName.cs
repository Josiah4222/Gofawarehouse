using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceShelfIdWithShelfName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Shelf_ShelfId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShelfId",
                table: "Items");

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

            migrationBuilder.RenameColumn(
                name: "ShelfId",
                table: "Items",
                newName: "ShelfName");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ShelfName",
                table: "Items",
                newName: "ShelfId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShelfId",
                table: "Items",
                column: "ShelfId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Shelf_ShelfId",
                table: "Items",
                column: "ShelfId",
                principalTable: "Shelf",
                principalColumn: "ShelfId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
