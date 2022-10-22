using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektApp.Persistence
{
    /*
     * A database class that represents the Bid table, created in the database via Entity Framework.
     */
    public class BidDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BidMaker { get; set; }

        [Required]
        public int OfferAmount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BidDate { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDb AuctionDb { get; set; }

        [Required]
        public int AuctionId { get; set; }
    }
}
