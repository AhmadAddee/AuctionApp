using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektApp.Persistence
{
    public class BidDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OfferAmount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        private DateTime BidDate { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }
    }
}
