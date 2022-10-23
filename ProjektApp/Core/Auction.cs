namespace ProjektApp.Core
{

    /* An object of this type is own by the user who creates it.
     * Might have unlimited amount of bids.
     * Concdered as completed when the time is expired.
     * 
     */
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AuctionOwner { get; set; }
        public float StartingPrice { get; set; }
        public float HighestBid { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;
        
        public Auction() { }
        
        private Auction (string title, string desc, string owner, float startPrice, float MaxPrice, string imgUrl)
        {
            Title = title; Description = desc; AuctionOwner = owner;
            StartingPrice = startPrice; HighestBid = MaxPrice;
            ImageUrl = imgUrl;// CreatedDate = DateTime.Now;
        }

        public static Auction CreateAuction(string title, string desc, string owner, float startPrice, float MaxPrice, string imgUrl)
        {
            return new Auction(title, desc, owner, startPrice, MaxPrice, imgUrl );
        }

        public void AddBid(Bid newBid)
        {
            {
                HighestBid = newBid.OfferAmount;
                _bids.Add(newBid);
            }
        }

        public bool IsExpired()
        {
            return ((DateTime.Now - CreatedDate).TotalHours >= 24);
        }

        public bool IsValidBidValue(float newValue)
        {
            return (newValue > HighestBid);
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - Expired: {IsExpired()}";
        }
    }
}
