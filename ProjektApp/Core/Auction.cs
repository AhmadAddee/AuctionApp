namespace ProjektApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; }
        public string Description { get; set; }
        public string AuctionOwner { get; }
        public float StartingPrice { get; }
        public float HighestBid { get; }
        public DateTime CreatedDate { get; }

        public List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(int id, string name, string description, string auctionOwner, float staringPrice)
        {
            Id = id;
            Name = name;
            Description = description;
            AuctionOwner = auctionOwner;
            StartingPrice = staringPrice;
            HighestBid = StartingPrice;
            CreatedDate = DateTime.Now;
        }

        public Auction(string name, string description, string auctionOwner, float staringPrice)
        {
            Name = name;
            Description = description;
            AuctionOwner = auctionOwner;
            StartingPrice = staringPrice;
            HighestBid = StartingPrice;
            CreatedDate = DateTime.Now;
        }

        // For mockdata
        public Auction(int id, string name, string description) { 
            Id = id;
            Name = name;
            CreatedDate = DateTime.Now;
            Description = description;
        }

        // For mockdata
        public Auction(string name, string description)
        {
            Name = name;
            Description = description;
            CreatedDate = DateTime.Now;
        }

        // For mockdata
        public Auction() { }

        public void AddBid(Bid newBid)
        {
            // TODO: Throw an exeption if the bid is lower. And check that the owner of this auction can't bid on it.
           if (!IsExpired() && newBid != null && newBid.OfferAmount > HighestBid) // insteade of: _bids.All(b => newBid.OfferAmount > b.OfferAmount)
            {
                _bids.Add(newBid);
            }
        }

        public bool IsExpired()
        {
            return ((DateTime.Now - CreatedDate).TotalHours >= 24);
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - Expired: {IsExpired()}";
        }
    }
}
