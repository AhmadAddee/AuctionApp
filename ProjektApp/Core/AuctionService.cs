using ProjektApp.Core.Interfaces;

namespace ProjektApp.Core
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;

        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public Auction GetById(int id)
        {
           return _auctionPersistence.GetById(id);
        }

        public void Add(Auction auction)
        {
            // Assume no bids in new auction
            if (auction == null || auction.Id != 0) throw new InvalidDataException();
            auction.CreatedDate = DateTime.Now;
            _auctionPersistence.Add(auction);
        }

        public void UpdateDesc(Auction auction)
        {
          //  if(auction == null || auction.Id != 0) throw new InvalidDataException();
            _auctionPersistence.UpdateDesc(auction);
        }

        public List<Auction> GetBidderAuctionByUserName(string userName)
        {
            return _auctionPersistence.GetBidderAuctionByUserName(userName);
        }

        public void AddBid(int auctionId, Bid bid)
        {
            _auctionPersistence.AddBid(auctionId, bid);
        }

        public bool InitateBid(int id, Bid bid)
        {
            return _auctionPersistence.InitateBid(id, bid);
        }

        public List<Auction> GetWinnerList(string userName)
        {
            return _auctionPersistence.GetWinnerList(userName);
        }

        //TODO: remove this method
        public void Delete(int id)
        {
            _auctionPersistence.Delete(id);
        }

        
    }
}
