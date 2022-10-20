using System.ComponentModel.DataAnnotations;

namespace ProjektApp.ViewModels
{
    public class CreateAuctionVM
    {
        [Required]
        [StringLength(100, ErrorMessage ="Max length 100 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public float StartingPrice { get; set; }
    }
}
