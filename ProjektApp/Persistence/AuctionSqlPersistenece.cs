using Microsoft.EntityFrameworkCore;
using ProjektApp.Core;
using ProjektApp.Core.Interfaces;

namespace ProjektApp.Persistence
{
    public class AuctionSqlPersistenece : IAuctionPersistence
    {
        private AuctionDbContext _dbContext;

        public AuctionSqlPersistenece(AuctionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDBs
                //.Where(a => true)
                //.Include(a => a.BidDBs)
                .ToList();

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB auct in auctionDbs)
            {
                Auction auction = new Auction(auct.Id, auct.Name, auct.Description);
                result.Add(auction);
            }
            return result;
        }
    }
}
