namespace ProjektApp.Core
{
    public class Bid
    {
        public int Id { get; set; }
        public int OfferAmount { get; }

        private DateTime _bidDate;
        public DateTime BidDate { get => _bidDate; }

        public Bid(int id, int offerAmount)
        {
            //BidMaker = bidMaker;
            Id = id;
            OfferAmount = offerAmount;
            _bidDate = DateTime.Now;
        }

        public Bid(int offerAmount)
        {
            //BidMaker = bidMaker;
            OfferAmount = offerAmount;
            _bidDate = DateTime.Now;
        }

        public Bid() { }

        public override string ToString()
        {
            return $"{Id}: offer: {OfferAmount} - {BidDate}";
        }

    }
}
