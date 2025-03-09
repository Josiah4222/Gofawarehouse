using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Gofabackend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveModel1IdFromItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Model1_Model1Id1",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Model1Id1",
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

            migrationBuilder.DropColumn(
                name: "Model1Id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Model1Id1",
                table: "Items");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c417fd9-f99e-4002-ac03-64900f2c447f", null, "VHF", "VHF" },
                    { "3a4b7eba-7336-483f-a093-193f84089279", null, "Manager", "MANAGER" },
                    { "3e5dc35c-07c1-4d1b-8150-158be9e6ad85", null, "HF", "HF" },
                    { "99081914-f1a4-4f6d-b92a-e86c6b13a1ba", null, "Transit", "TRANSIT" },
                    { "ba779a98-9375-4082-82ce-02e845bde349", null, "Electronics", "ELECTRONICS" },
                    { "bafe8fe2-dd9d-4de6-b339-d8e1bc302195", null, "Sparepart", "SPAREPART" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c417fd9-f99e-4002-ac03-64900f2c447f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a4b7eba-7336-483f-a093-193f84089279");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e5dc35c-07c1-4d1b-8150-158be9e6ad85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99081914-f1a4-4f6d-b92a-e86c6b13a1ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba779a98-9375-4082-82ce-02e845bde349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bafe8fe2-dd9d-4de6-b339-d8e1bc302195");

            migrationBuilder.AddColumn<string>(
                name: "Model1Id",
                table: "Items",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Model1Id1",
                table: "Items",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_Items_Model1Id1",
                table: "Items",
                column: "Model1Id1");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Model1_Model1Id1",
                table: "Items",
                column: "Model1Id1",
                principalTable: "Model1",
                principalColumn: "Model1Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
