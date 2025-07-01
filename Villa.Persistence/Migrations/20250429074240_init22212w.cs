using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class init22212w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 24);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 20, "Pool, Gym", new DateTime(2025, 4, 29, 11, 11, 14, 897, DateTimeKind.Local).AddTicks(9719), "Luxurious villa with a private pool and gym.", "https://example.com/royal-villa.jpg", "Royal Villa", 5, 200.0, 500, new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9445) },
                    { 22, "Beach Access, Spa", new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9761), "Beautiful villa with direct beach access and spa services.", "https://example.com/beachfront-villa.jpg", "Beachfront Villa", 4, 250.0, 400, new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9764) },
                    { 23, "Hiking, Fireplace", new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9766), "Cozy villa with stunning mountain views and a fireplace.", "https://example.com/mountain-view-villa.jpg", "Mountain View Villa", 6, 180.0, 600, new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9767) },
                    { 24, "Private Chef, Pool", new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9768), "Spacious villa with a private chef and pool.", "https://example.com/luxury-villa.jpg", "Luxury Villa", 8, 300.0, 800, new DateTime(2025, 4, 29, 11, 11, 14, 900, DateTimeKind.Local).AddTicks(9769) }
                });
        }
    }
}
