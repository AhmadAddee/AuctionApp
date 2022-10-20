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
        public DateTime CreatedDate { get; set; }

        public List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(int id, string title, string description, string auctionOwner, float staringPrice)
        {
            Id = id;
            Title = title;
            Description = description;
            AuctionOwner = auctionOwner;
            StartingPrice = staringPrice;
            HighestBid = StartingPrice;
            CreatedDate = DateTime.Now;
        }

        public Auction(string title, string description, float staringPrice)
        {
            Title = title;
            Description = description;
            StartingPrice = staringPrice;
            HighestBid = StartingPrice;
            CreatedDate = DateTime.Now;
        }

        public Auction(string title, string description, string auctionOwner, float staringPrice)
        {
            Title = title;
            Description = description;
            AuctionOwner = auctionOwner;
            StartingPrice = staringPrice;
            HighestBid = StartingPrice;
            CreatedDate = DateTime.Now;
        }

        // For mockdata
        public Auction(int id, string title, string description) { 
            Id = id;
            Title = title;
            CreatedDate = DateTime.Now;
            Description = description;
        }

        // For mockdata
        public Auction(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
        }

        // For mockdata
        public Auction() { }

        public void AddBid(Bid newBid)
        {
            // TODO: Throw an exeption if the bid is lower. And check that the owner of this auction can't bid on it.
           //if (!IsExpired() && newBid != null && IsValidBidValue(newBid.OfferAmount)) 
            {
                HighestBid = newBid.OfferAmount;
                _bids.Add(newBid);
            }
        }

        public bool IsExpired()
        {
            return ((DateTime.Now - CreatedDate).TotalHours >= 24);
        }

        public bool IsValidBidValue(float newValue)// insteade of: _bids.All(b => newBid.OfferAmount > b.OfferAmount)
        {
            return (newValue > HighestBid);
        }

        public override string ToString()
        {
            return $"{Id}: {Title} - Expired: {IsExpired()}";
        }
    }
}
