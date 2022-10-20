using AutoMapper;
using ProjektApp.Core;
using ProjektApp.Persistence;

namespace ProjektApp.Mappings
{
    public class BidProfile : Profile
    {
        public BidProfile()
        {
            //Default mapping when property names are same
            CreateMap<BidDb, Bid>()
                .ReverseMap();
        }
    }
}
