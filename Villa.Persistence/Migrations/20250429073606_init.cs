using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 29, 11, 6, 6, 64, DateTimeKind.Local).AddTicks(3451), new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5785), new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5789), new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5789) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5791), new DateTime(2025, 4, 29, 11, 6, 6, 67, DateTimeKind.Local).AddTicks(5791) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 10, 15, 271, DateTimeKind.Local).AddTicks(3270), new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3011), new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3013) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3015), new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3016) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3017), new DateTime(2025, 4, 23, 11, 10, 15, 274, DateTimeKind.Local).AddTicks(3018) });
        }
    }
}
