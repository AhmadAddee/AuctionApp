namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction GetById(int id);
        void Add(Auction auction);

        void UpdateDesc( Auction auction);
    }
}
