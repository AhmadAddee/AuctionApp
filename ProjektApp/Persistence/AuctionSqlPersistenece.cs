using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;
using ProjektApp.ViewModels;
using System.Linq;

namespace ProjektApp.Persistence
{
    public class AuctionSqlPersistenece : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;
        private IMapper _mapper;

        public AuctionSqlPersistenece(AuctionDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // Filter the list so that only ongoing auction is stored in it.
        // Query the database after auctions where their cretedDate is lower than 24 h.
        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDbs.AsEnumerable()
                .Where(a => _mapper.Map<Auction>(a).IsExpired() == false)
                .ToList();

            List<Auction> result = new List<Auction>();
            if (auctionDbs != null)
            {
                foreach (AuctionDb auct in auctionDbs)
                {
                    Auction auction = _mapper.Map<Auction>(auct);
                    result.Add(auction);
                }
            }
            return result;
        }

        // used to view the details (and relative bids) of a specifik auction
        public Auction GetById(int id)
        {
            // eager loading
            var auctionDb = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .AsEnumerable()
                .Where(a => a.Id == id && _mapper.Map<Auction>(a).IsExpired() == false)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            if (auction != null)
            {
                foreach (BidDb bdb in auctionDb.BidDbs)
                {
                    auction.AddBid(_mapper.Map<Bid>(bdb));
                }
            }
            return auction;
        }

        public void Add(Auction auction)
        {
            AuctionDb adp = _mapper.Map<AuctionDb>(auction);

            if (adp != null)
            {
                _dbContext.AuctionDbs.Add(adp);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateDesc(Auction auction)
        {
            var adb = _dbContext.AuctionDbs
                 .Where(a => a.Id == auction.Id)
                 .SingleOrDefault();
            if (adb != null)
            {
                adb.Description = auction.Description;
                _dbContext.SaveChanges();
            }
        }

        // Query the databse to retrieve all ongoing auction that a specific user has a bid on.
        public List<Auction> GetBidderAuctionByUserName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDbs
                .AsEnumerable()
                .Where(a => (_mapper.Map<Auction>(a).IsExpired() == false) && _dbContext.BidDbs.Any(b => a.Id == b.AuctionId && b.BidMaker.Equals(userName)))
                .ToList();

            List<Auction> result = new List<Auction>();
            if (auctionDbs != null)
            {
                foreach (AuctionDb auct in auctionDbs)
                {
                    Auction auction = _mapper.Map<Auction>(auct);
                    result.Add(auction);
                }
            }
            return result;
        }

        public bool InitateBid(int id, Bid bid)
        {

            var auctionDd = _dbContext.AuctionDbs.Where(a => a.Id == id).SingleOrDefault();

            var BidDb = _dbContext.BidDbs.OrderBy(a => a.OfferAmount).Where(a => a.AuctionId == id).FirstOrDefault();

            if (BidDb == null && auctionDd != null)
            {
                if (bid.OfferAmount > auctionDd.StartingPrice && bid.OfferAmount > auctionDd.HighestBid)
                {
                    BidDb adp = _mapper.Map<BidDb>(bid);
                    auctionDd.HighestBid = bid.OfferAmount;
                    _dbContext.BidDbs.Add(adp);
                    adp.AuctionId = id;
                    _dbContext.SaveChanges();
                    return true;
                }
            }

            if (BidDb != null && auctionDd != null)
            {
                var auctionDb = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .Where(a => a.Id == id)
                .SingleOrDefault();
                var max = auctionDb.BidDbs.Max(o => o.OfferAmount);

                if (bid.OfferAmount > max)
                {
                    BidDb adp = _mapper.Map<BidDb>(bid);
                    _dbContext.BidDbs.Add(adp);
                    adp.AuctionId = id;
                    auctionDb.HighestBid = adp.OfferAmount;
                    _dbContext.SaveChanges();
                    return true;
                }
            }


            return false;

        }

        public List<Auction> GetWinnerList(string userName)
        {

            var auctionDbs = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .AsEnumerable()
                .Where(a => (_mapper.Map<Auction>(a).IsExpired() == true)
                && a.BidDbs.Any(b => a.Id == b.AuctionId && b.BidMaker.Equals(userName)
                && b.OfferAmount == a.BidDbs.Max(m => m.OfferAmount)))
                .ToList();

            List<Auction> result = new List<Auction>();
            if (auctionDbs != null)
            {
                foreach (AuctionDb auct in auctionDbs)
                {
                    Auction auction = _mapper.Map<Auction>(auct);
                    result.Add(auction);
                }
            }
            return result;
        }
    }
}
