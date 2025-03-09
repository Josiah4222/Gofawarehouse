using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedControllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4a0986-f25d-40ea-ad5c-29bdba5c9b58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c223bff-3269-483c-ab06-9e8c3576176b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "183fc6d5-1738-452e-8dbd-196a9b04b72a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "635c90ac-433b-4c25-a6ac-667b6c3076eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b016ad38-436f-41f4-ac84-d9d46ee7909f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a13fb2-f1c7-4de8-9d08-b35f14839b59");

            migrationBuilder.CreateTable(
                name: "ItemType",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemType", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Model1",
                columns: table => new
                {
                    Model1Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Supplier = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    PRNO = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InvoiceNo = table.Column<string>(type: "TEXT", nullable: false),
                    ItemType = table.Column<string>(type: "TEXT", nullable: false),
                    ContactNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredBy = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasurment = table.Column<string>(type: "TEXT", nullable: false),
                    Quality = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitOfPrice = table.Column<float>(type: "REAL", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Remark = table.Column<string>(type: "TEXT", nullable: false),
                    checkedByName = table.Column<string>(type: "TEXT", nullable: false),
                    RecivedByName = table.Column<string>(type: "TEXT", nullable: false),
                    AuthorizedByName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model1", x => x.Model1Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    ShelfId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Column = table.Column<string>(type: "TEXT", nullable: false),
                    Row = table.Column<string>(type: "TEXT", nullable: false),
                    WarehouseId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.ShelfId);
                    table.ForeignKey(
                        name: "FK_Shelf_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    VoucherNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ReceivedFrom = table.Column<string>(type: "TEXT", nullable: false),
                    Condition = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    NumOfBox = table.Column<int>(type: "INTEGER", nullable: false),
                    RegisteredBy = table.Column<string>(type: "TEXT", nullable: false),
                    ItemType = table.Column<string>(type: "TEXT", nullable: false),
                    Model1Id = table.Column<string>(type: "TEXT", nullable: false),
                    Model1Id1 = table.Column<int>(type: "INTEGER", nullable: false),
                    ShelfId = table.Column<string>(type: "TEXT", nullable: false),
                    ShelfId1 = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Model1_Model1Id1",
                        column: x => x.Model1Id1,
                        principalTable: "Model1",
                        principalColumn: "Model1Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Shelf_ShelfId1",
                        column: x => x.ShelfId1,
                        principalTable: "Shelf",
                        principalColumn: "ShelfId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_Model1Id1",
                table: "Items",
                column: "Model1Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShelfId1",
                table: "Items",
                column: "ShelfId1");

            migrationBuilder.CreateIndex(
                name: "IX_Shelf_WarehouseId",
                table: "Shelf",
                column: "WarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemType");

            migrationBuilder.DropTable(
                name: "Model1");

            migrationBuilder.DropTable(
                name: "Shelf");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0a4a0986-f25d-40ea-ad5c-29bdba5c9b58", null, "Manager", "MANAGER" },
                    { "0c223bff-3269-483c-ab06-9e8c3576176b", null, "Electronics", "ELECTRONICS" },
                    { "183fc6d5-1738-452e-8dbd-196a9b04b72a", null, "HF", "HF" },
                    { "635c90ac-433b-4c25-a6ac-667b6c3076eb", null, "Transit", "TRANSIT" },
                    { "b016ad38-436f-41f4-ac84-d9d46ee7909f", null, "Sparepart", "SPAREPART" },
                    { "f4a13fb2-f1c7-4de8-9d08-b35f14839b59", null, "VHF", "VHF" }
                });
        }
    }
}
