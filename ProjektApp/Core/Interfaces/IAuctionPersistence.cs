namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionPersistence
    {
        List<Auction> GetAll();

        Auction GetById(int id);

        void Add(Auction auction);
    }
}
