using Microsoft.EntityFrameworkCore;

namespace ProjektApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDB> BidDbs { get; set; }
        public DbSet<AuctionDB> AuctionDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    Name = "The new data from the database!!",
                    Description = "This is the description"
                });
        }
    }
}
