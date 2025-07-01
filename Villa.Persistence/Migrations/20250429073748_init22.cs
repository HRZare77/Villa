using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Villa.Migrations
{
    /// <inheritdoc />
    public partial class init22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Pool, Gym", new DateTime(2025, 4, 29, 11, 7, 47, 438, DateTimeKind.Local).AddTicks(8484), "Luxurious villa with a private pool and gym.", "https://example.com/royal-villa.jpg", "Royal Villa", 5, 200.0, 500, new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4349) },
                    { 2, "Beach Access, Spa", new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4970), "Beautiful villa with direct beach access and spa services.", "https://example.com/beachfront-villa.jpg", "Beachfront Villa", 4, 250.0, 400, new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4972) },
                    { 3, "Hiking, Fireplace", new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4974), "Cozy villa with stunning mountain views and a fireplace.", "https://example.com/mountain-view-villa.jpg", "Mountain View Villa", 6, 180.0, 600, new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4974) },
                    { 4, "Private Chef, Pool", new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4976), "Spacious villa with a private chef and pool.", "https://example.com/luxury-villa.jpg", "Luxury Villa", 8, 300.0, 800, new DateTime(2025, 4, 29, 11, 7, 47, 441, DateTimeKind.Local).AddTicks(4976) }
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
        }
    }
}
