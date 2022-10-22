namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction GetById(int id);
        void Add(Auction auction);

        void UpdateDesc( Auction auction);

        List<Auction> GetBidderAuctionByUserName(string userName);

        List<Auction> GetWinnerList(string userName);

        void AddBid(int auctionId, Bid bid);

        bool InitateBid(int id, Bid bid);

        //TODO: remove this method.
        void Delete(int id);
    }
}
