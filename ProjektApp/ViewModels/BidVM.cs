using ProjektApp.Core;

namespace ProjektApp.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public float Offer_Amount { get; set; }
        public DateTime Bid_Date { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Offer_Amount = bid.OfferAmount,
                Bid_Date = bid.BidDate,
            };
        }
    }
}
