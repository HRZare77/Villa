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
        //public DbSet<VillaNumber> VillaNumbers { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<RoomDetails> RoomDetails { get; set; }
    }
}
