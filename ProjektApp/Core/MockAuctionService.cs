using ProjektApp.Core.Interfaces;

namespace ProjektApp.Core
{ 
    public class MockAuctionService //: IAuctionService
    {

        public List<Auction> GetAll()
        {
            Auction a1 = new(1, "first", "hylla", "Ahmad", 1509);
            Auction a2 = new(2, "name", "desx", "Najiib", 1599);
            Bid b = new(1, "Anna", 2000);
            Bid b2 = new(2, "Nansi", 3000);
            a1.AddBid(b);
            a2.AddBid(b2);

            List<Auction> auctions = new();
            auctions.Add(a1);
            auctions.Add(a2);
            return auctions;
        }
    }
}
