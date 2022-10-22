using System.ComponentModel.DataAnnotations;

namespace ProjektApp.ViewModels
{
    public class MakeABidVM
    {
        [Required]
        public int OfferAmount { get; set; }
    }
}
