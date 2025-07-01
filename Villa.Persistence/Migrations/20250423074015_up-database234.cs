using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class updatabase234 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 8, 30, 705, DateTimeKind.Local).AddTicks(1815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 8, 30, 708, DateTimeKind.Local).AddTicks(143), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 8, 30, 708, DateTimeKind.Local).AddTicks(156), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 8, 30, 708, DateTimeKind.Local).AddTicks(158), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
