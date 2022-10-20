namespace ProjektApp.Core.Interfaces
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction GetById(int id);
    }
}
