namespace ProjektApp.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; }

        public List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(int id, string name, string description) { 
            Id = id;
            Name = name;
            CreatedDate = DateTime.Now;
            Description = description;
        }

        public Auction(string name, string description)
        {
            Name = name;
            Description = description;
            CreatedDate = DateTime.Now;
        }

        public Auction() { }

        public void AddBid(Bid newBid)
        {
           //if (!IsExpired() && newBid != null && _bids.All(b => newBid.OfferAmount > b.OfferAmount))
                _bids.Add(newBid);
        }

        public bool IsExpired()
        {
            return (DateTime.Now.ToOADate() - CreatedDate.ToOADate() >= 24);
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - Expired: {IsExpired()}";
        }
    }
}
