using Microsoft.Data.SqlClient.Server;
using ProjektApp.Core;

namespace ProjektApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public float Starting_Price { get; set; }
        public DateTime Created_Date { get; set; }
        public bool Is_Expired { get; set; }
        public int MaxValue { get; set; }

        public List<BidVM> BidVMs { get; set; } = new List<BidVM>();

        public static AuctionVM FromAuction(Auction auction)
        {
            List<BidVM> bids = new List<BidVM>();
            foreach(Bid bid in auction.Bids)
            {
                BidVM bidVM = new BidVM()
                {
                    Id = bid.Id,
                    Offer_Amount = bid.OfferAmount,
                    BidMaker = bid.BidMaker,
                    Bid_Date = bid.BidDate,
                };
                bids.Add(bidVM);
            }
            return new AuctionVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                //Auction_Owner = auction.AuctionOwner,
                BidVMs = bids,
                Starting_Price = auction.StartingPrice,
                Created_Date = auction.CreatedDate,
                Is_Expired = auction.IsExpired()
            };
        }
    }
}
