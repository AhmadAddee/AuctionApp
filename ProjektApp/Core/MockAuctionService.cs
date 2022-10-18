using ProjektApp.Core.Interfaces;

namespace ProjektApp.Core
{ 
    public class MockAuctionService : IAuctionService
    {

        public List<Auction> GetAll()
        {
            Auction a1 = new(1, "first", "hylla");
            Auction a2 = new(2, "second", "hylla");
            Bid b = new( 1500);
            Bid b2 = new(1300);
            a1.AddBid(b);
            a2.AddBid(b2);

            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            return auctions;
        }
    }
}
