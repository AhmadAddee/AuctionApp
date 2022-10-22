using ProjektApp.Core;

namespace ProjektApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public int Offer_Amount { get; set; }
        public int AuctionId { get; set; }
        public string BidMaker { get; set; }
        public DateTime Bid_Date { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Offer_Amount = bid.OfferAmount,
                BidMaker = bid.BidMaker,
                Bid_Date = bid.BidDate,
            };
        }
    }
}
