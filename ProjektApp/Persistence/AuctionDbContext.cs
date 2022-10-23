using Microsoft.EntityFrameworkCore;

namespace ProjektApp.Persistence
{
    public class AuctionDbContext : DbContext
    { 
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
                AuctionOwner = "ahmadak@kth.se",
                StartingPrice = 100,
                HighestBid = 100,
                ImageUrl = "https://tinyjpg.com/images/social/website.jpg",
                CreatedDate = DateTime.Now,
                BidDbs = new List<BidDb>()
            };
            modelBuilder.Entity<AuctionDb>().HasData(adb);

            BidDb bdb1 = new BidDb()
            {
                Id = -1,
                OfferAmount = 120,
                BidMaker = "Najiib27@hotmail.se",
                BidDate = DateTime.Now,
                AuctionId = -1,
            };
            BidDb bdb2 = new BidDb()
            {
                Id = -2,
                OfferAmount = 140,
                BidMaker = "Najiib27@hotmail.se",
                BidDate = DateTime.Now,
                AuctionId = -1,
            };
            modelBuilder.Entity<BidDb>().HasData(bdb1);
            modelBuilder.Entity<BidDb>().HasData(bdb2);

        }
    }
}
