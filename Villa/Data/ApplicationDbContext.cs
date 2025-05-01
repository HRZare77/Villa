using Microsoft.EntityFrameworkCore;
using Villa.Models;

namespace Villa.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Villa.Models.Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<RoomDetails> RoomDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa.Models.Villa>().HasData(

                new Villa.Models.Villa
                {
                    Id =1,
                    Name = "Royal Villa",
                    Occupancy = 5,
                    Sqft = 500,
                    ImageUrl = "https://example.com/royal-villa.jpg",
                    Amenity = "Pool, Gym",
                    Details = "Luxurious villa with a private pool and gym.",
                    Rate = 200.00,
                    CreatedDate = new DateTime(2024, 01, 01),
                    UpdatedDate = new DateTime(2024, 01, 01)
                },
                new Villa.Models.Villa
                {
                    Id = 2,
                    Name = "Beachfront Villa",
                    Occupancy = 4,
                    Sqft = 400,
                    ImageUrl = "https://example.com/beachfront-villa.jpg",
                    Amenity = "Beach Access, Spa",
                    Details = "Beautiful villa with direct beach access and spa services.",
                    Rate = 250.00,
                    CreatedDate = new DateTime(2024, 01, 01),
                    UpdatedDate = new DateTime(2024, 01, 01)
                },
                new Villa.Models.Villa
                {
                    Id =3,
                    Name = "Mountain View Villa",
                    Occupancy = 6,
                    Sqft = 600,
                    ImageUrl = "https://example.com/mountain-view-villa.jpg",
                    Amenity = "Hiking, Fireplace",
                    Details = "Cozy villa with stunning mountain views and a fireplace.",
                    Rate = 180.00,
                    CreatedDate = new DateTime(2024, 01, 01),
                    UpdatedDate = new DateTime(2024, 01, 01)
                },
                new Villa.Models.Villa
                {
                    Id = 4,
                    Name = "Luxury Villa",
                    Occupancy = 8,
                    Sqft = 800,
                    ImageUrl = "https://example.com/luxury-villa.jpg",
                    Amenity = "Private Chef, Pool",
                    Details = "Spacious villa with a private chef and pool.",
                    Rate = 300.00,
                    CreatedDate = new DateTime(2024, 01, 01),
                    UpdatedDate = new DateTime(2024, 01, 01)
                }
                );
        }
    }
}


