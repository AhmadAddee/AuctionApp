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

        bool InitateBid(int id, Bid bid);

        Auction CreateAuction(string title, string desc, string owner, float startPrice, float MaxPrice, string imgUrl);
    }
}
