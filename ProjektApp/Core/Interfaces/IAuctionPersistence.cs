namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();

        Auction GetById(int id);

        void Add(Auction auction);

        void UpdateDesc(Auction auction);

        List<Auction> GetBidderAuctionByUserName(string userName);

        List<Auction> GetWinnerList(string userName);

        bool InitateBid(int id, Bid bid);
    }
}
