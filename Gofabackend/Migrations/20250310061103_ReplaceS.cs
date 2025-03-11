using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "MasterCard",
                columns: table => new
                {
                    MasterCardId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    PartNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    UM = table.Column<string>(type: "TEXT", nullable: false),
                    InCHAb = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPack = table.Column<string>(type: "TEXT", nullable: false),
                    LeadTime = table.Column<string>(type: "TEXT", nullable: false),
                    AvgUsage = table.Column<string>(type: "TEXT", nullable: false),
                    SSL = table.Column<string>(type: "TEXT", nullable: false),
                    MaxLevel = table.Column<string>(type: "TEXT", nullable: false),
                    RecordPoint = table.Column<string>(type: "TEXT", nullable: false),
                    VED = table.Column<string>(type: "TEXT", nullable: false),
                    ABC = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderNo = table.Column<int>(type: "INTEGER", nullable: false),
                    Consigning = table.Column<string>(type: "TEXT", nullable: false),
                    QYTOrder = table.Column<string>(type: "TEXT", nullable: false),
                    QYT = table.Column<string>(type: "TEXT", nullable: false),
                    VoucherNo = table.Column<string>(type: "TEXT", nullable: false),
                    Received = table.Column<string>(type: "TEXT", nullable: false),
                    Issued = table.Column<string>(type: "TEXT", nullable: false),
                    InStock = table.Column<string>(type: "TEXT", nullable: false),
                    UnitPrice = table.Column<string>(type: "TEXT", nullable: false),
                    ORG = table.Column<string>(type: "TEXT", nullable: false),
                    Postedby = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCard", x => x.MasterCardId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11704799-5678-4f7a-be99-cff132a7991f", null, "Transit", "TRANSIT" },
                    { "369af6c4-7807-4f72-b1e0-513368000873", null, "VHF", "VHF" },
                    { "4b6f3e83-abe6-414a-802b-987aa36ca220", null, "Sparepart", "SPAREPART" },
                    { "ad708a37-8e0b-43be-8cc1-19fd24225a38", null, "Electronics", "ELECTRONICS" },
                    { "c6a1b5ee-3606-4882-871d-f69d3dedd6da", null, "HF", "HF" },
                    { "e594f141-e176-4471-88d6-df593d318a36", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterCard");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11704799-5678-4f7a-be99-cff132a7991f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "369af6c4-7807-4f72-b1e0-513368000873");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b6f3e83-abe6-414a-802b-987aa36ca220");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad708a37-8e0b-43be-8cc1-19fd24225a38");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6a1b5ee-3606-4882-871d-f69d3dedd6da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e594f141-e176-4471-88d6-df593d318a36");

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
    }
}
