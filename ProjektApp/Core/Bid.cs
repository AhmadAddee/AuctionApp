namespace ProjektApp.Core
{
   /*
    * Must have info about the user how made the bid, and the date and time it was been made.
    * 
    */
    public class Bid
    {
        public int Id { get; set; }
        public string BidMaker { get; set; }
        public float OfferAmount { get; set; }

        private DateTime _bidDate;
        public DateTime BidDate { get => _bidDate; }

        public Bid(int id, string bidMaker, float offerAmount)
        {
            BidMaker = bidMaker;
            Id = id;
            OfferAmount = offerAmount;
            _bidDate = DateTime.Now;
        }

        // For mock data
        public Bid(int id, int offerAmount)
        {
            Id = id;
            OfferAmount = offerAmount;
            _bidDate = DateTime.Now;
        }

        // For mock data
        public Bid(int offerAmount)
        {
            OfferAmount = offerAmount;
            _bidDate = DateTime.Now;
        }

        // For mock data
        public Bid() { }

        public override string ToString()
        {
            return $"{Id}: offer: {OfferAmount} - {BidDate}";
        }

    }
}
