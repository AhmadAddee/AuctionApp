using Microsoft.EntityFrameworkCore;

namespace ProjektApp.Persistence
{
    public class AuctionDbContext : DbContext
    {
        /*
         * Represents the connection itself to the databese, and contains the objects just read from the database.
         */
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options) : base(options) { }

        public DbSet<BidDb> BidDbs { get; set; }
        public DbSet<AuctionDb> AuctionDbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuctionDb adb = new AuctionDb
            {
                Id = -1,
                Title = "The title",
                Description = "The description",
                StartingPrice = 100,
                CreatedDate = DateTime.Now,
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb1 = new BidDb()
            {
                Id = -1,
                OfferAmount = 120,
                BidDate = DateTime.Now,
                AuctionId = -1,
            };
            BidDb bdb2 = new BidDb()
            {
                Id = -2,
                OfferAmount = 140,
                BidDate = DateTime.Now,
                AuctionId = -1,
            };
            modelBuilder.Entity<BidDb>().HasData(bdb1);
            modelBuilder.Entity<BidDb>().HasData(bdb2);

        }
    }
}
