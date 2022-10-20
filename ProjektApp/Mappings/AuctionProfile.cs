using AutoMapper;
using ProjektApp.Core;
using ProjektApp.Persistence;

namespace ProjektApp.Mappings
{
    public class AuctionProfile : Profile
    {
        public AuctionProfile()
        {
            // Default mapping when property names are same
            CreateMap<AuctionDb, Auction>()
                .ReverseMap();
        }
    }
}
