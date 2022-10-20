using ProjektApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjektApp.Persistence
{
    /*
     * A database class that represents the Auction table, created in the database via Entity Framework.
     */
    public class AuctionDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public float StartingPrice { get; set; }
        
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public List<BidDb> BidDbs { get; set; } = new List<BidDb>();
    }
}
