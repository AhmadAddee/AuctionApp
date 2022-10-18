using ProjektApp.Core;

namespace ProjektApp.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Name = auction.Name,
                CreatedDate = auction.CreatedDate,
                Description = auction.Description
            };
        }
    }
}
