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
        public int OfferAmount { get; set; }
        public int AuctionId { get; set; }
        public DateTime BidDate { get; set; }

        public Bid() { }

        public override string ToString()
        {
            return $"{Id}: offer: {OfferAmount} - {BidDate}";
        }

    }
}
