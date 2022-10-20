using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;

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

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDbs.ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDb auct in auctionDbs)
            {
               Auction auction = _mapper.Map<Auction>(auct);
                result.Add(auction);
            }
            return result;
        }

        public Auction GetById(int id)
        {
            // eager loading
            var auctionDb = _dbContext.AuctionDbs
                .Include(a => a.BidDbs)
                .Where(a => a.Id == id)
                .SingleOrDefault();

            Auction auction = _mapper.Map<Auction>(auctionDb);
            foreach(BidDb bdb in auctionDb.BidDbs)
            {
                auction.AddBid(_mapper.Map<Bid>(bdb));
            }
            return auction;
        }
    }
}

/**
 * To query the database;
 * One object:
 * - var auctionDb = _dbContext.AuctionDbs.Find(1);
 * - var auctionDb = _dbContext.AuctionDbs
 *      .Where(a => a.Id == id)
 *      .SingleOrDefault();
 * Multiple objects: (Lazy loading)
 * - var auctionDbs = _dbContext.AuctionDbs
 *      .Where(a => [some predicate] )
 *      .ToList();
 * Multiple objects: (Eger loading)
 * - var auctionDbs = _dbContext.AuctionDbs
 *      .Where(a => [some predicate] )
 *      .Include(a = a.BidDbs)
 *      .ToList();
 */
