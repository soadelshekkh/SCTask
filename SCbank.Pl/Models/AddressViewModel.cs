using System.ComponentModel.DataAnnotations;

namespace SCbank.Pl.Models
{
    public class AddressViewModel
    {
        [Required(ErrorMessage ="Please enter your street name")]
        [RegularExpression(@"^[a-zA-Z ]{3,50}$", ErrorMessage = "Please enter valid street name only accept Alphabet letters")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter your city name")]
        [RegularExpression(@"^[a-zA-Z ]{3,50}$", ErrorMessage = "Please enter valid city name only accept Alphabet letters")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your country name")]
        [RegularExpression(@"^[a-zA-Z ]{3,50}$", ErrorMessage = "Please enter valid country name only accept Alphabet letters")]
        public string Country { get; set; }
    }
}
