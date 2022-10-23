﻿using ProjektApp.Core;

namespace ProjektApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuctionOwner { get; set; }
        public float Starting_Price { get; set; }
        public float HighestBid { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created_Date { get; set; }
        public bool Is_Expired { get; set; }
        public List<BidVM> BidVMs { get; set; } = new List<BidVM>();

        public static AuctionVM FromAuction(Auction auction)
        {
            var auctionVM = new AuctionVM()
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                AuctionOwner = auction.AuctionOwner,
                Starting_Price = auction.StartingPrice,
                HighestBid = auction.HighestBid,
                ImageUrl = auction.ImageUrl,
                Created_Date = auction.CreatedDate,
                Is_Expired = auction.IsExpired()
            };

            foreach (var bid in auction.Bids)
            {
                auctionVM.BidVMs.Add(BidVM.FromBid(bid));
            }

            return auctionVM;
        }
    }
}
