using ProjektApp.Core;
using System.ComponentModel.DataAnnotations;

namespace ProjektApp.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(400)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; }

        public IEnumerable<BidDB> BidDBs { get; set; } = new List<BidDB>();
    }
}
