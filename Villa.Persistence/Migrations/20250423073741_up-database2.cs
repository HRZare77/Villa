using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class updatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Villas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Villas",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3211), new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3453) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3648), new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3651), new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3652) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3654), new DateTime(2025, 4, 23, 11, 7, 41, 338, DateTimeKind.Local).AddTicks(3654) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Villas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Villas",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1465), new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1717) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1914), new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1915) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1917), new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1917) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1919), new DateTime(2025, 4, 23, 11, 6, 38, 506, DateTimeKind.Local).AddTicks(1919) });
        }
    }
}
