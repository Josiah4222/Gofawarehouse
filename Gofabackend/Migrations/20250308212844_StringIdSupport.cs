using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class StringIdSupport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Shelf_ShelfId1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ShelfId1",
                table: "Items");

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

            migrationBuilder.DropColumn(
                name: "ShelfId1",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "ShelfId",
                table: "Shelf",
                type: "TEXT",
                maxLength: 36,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17639078-abc7-4724-98c4-b2f7681bd5ff", null, "Manager", "MANAGER" },
                    { "402045b1-9ae4-46a9-bc54-9d19edbbb139", null, "HF", "HF" },
                    { "6620a70d-576d-4aad-a3db-1e71c7a68665", null, "Transit", "TRANSIT" },
                    { "902254a9-29e3-4fbb-bee0-c8f69cdd5418", null, "VHF", "VHF" },
                    { "d5777f14-c6f2-476a-b47d-49b17bea0dff", null, "Electronics", "ELECTRONICS" },
                    { "ff1afb46-b6ff-428c-9360-67f977920e07", null, "Sparepart", "SPAREPART" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "17639078-abc7-4724-98c4-b2f7681bd5ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "402045b1-9ae4-46a9-bc54-9d19edbbb139");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6620a70d-576d-4aad-a3db-1e71c7a68665");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "902254a9-29e3-4fbb-bee0-c8f69cdd5418");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5777f14-c6f2-476a-b47d-49b17bea0dff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff1afb46-b6ff-428c-9360-67f977920e07");

            migrationBuilder.AlterColumn<int>(
                name: "ShelfId",
                table: "Shelf",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 36)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "WarehouseName",
                table: "Shelf",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ShelfId1",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShelfId1",
                table: "Items",
                column: "ShelfId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Shelf_ShelfId1",
                table: "Items",
                column: "ShelfId1",
                principalTable: "Shelf",
                principalColumn: "ShelfId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
