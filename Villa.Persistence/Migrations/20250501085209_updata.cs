using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class updata : Migration
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

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Pool, Gym", new DateTime(2025, 5, 1, 12, 22, 9, 62, DateTimeKind.Local).AddTicks(6950), "Luxurious villa with a private pool and gym.", "https://example.com/royal-villa.jpg", "Royal Villa", 5, 200.0, 500, new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8066) },
                    { 2, "Beach Access, Spa", new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8397), "Beautiful villa with direct beach access and spa services.", "https://example.com/beachfront-villa.jpg", "Beachfront Villa", 4, 250.0, 400, new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8400) },
                    { 3, "Hiking, Fireplace", new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8402), "Cozy villa with stunning mountain views and a fireplace.", "https://example.com/mountain-view-villa.jpg", "Mountain View Villa", 6, 180.0, 600, new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8402) },
                    { 4, "Private Chef, Pool", new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8404), "Spacious villa with a private chef and pool.", "https://example.com/luxury-villa.jpg", "Luxury Villa", 8, 300.0, 800, new DateTime(2025, 5, 1, 12, 22, 9, 65, DateTimeKind.Local).AddTicks(8405) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 20, "Pool, Gym", new DateTime(2025, 4, 29, 11, 13, 2, 891, DateTimeKind.Local).AddTicks(9358), "Luxurious villa with a private pool and gym.", "https://example.com/royal-villa.jpg", "Royal Villa", 5, 200.0, 500, new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(2964) },
                    { 22, "Beach Access, Spa", new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3279), "Beautiful villa with direct beach access and spa services.", "https://example.com/beachfront-villa.jpg", "Beachfront Villa", 4, 250.0, 400, new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3281) },
                    { 23, "Hiking, Fireplace", new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3283), "Cozy villa with stunning mountain views and a fireplace.", "https://example.com/mountain-view-villa.jpg", "Mountain View Villa", 6, 180.0, 600, new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3284) },
                    { 24, "Private Chef, Pool", new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3286), "Spacious villa with a private chef and pool.", "https://example.com/luxury-villa.jpg", "Luxury Villa", 8, 300.0, 800, new DateTime(2025, 4, 29, 11, 13, 2, 894, DateTimeKind.Local).AddTicks(3287) }
                });
        }
    }
}
