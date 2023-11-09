using System.ComponentModel.DataAnnotations;

namespace SCbank.Pl.Models
{
    public class CustomerTypeViewModel
    {
        [Required(ErrorMessage = "please enter new customer type name")]
        [RegularExpression(@"^[a-zA-Z ]{3,50}$", ErrorMessage = "Please enter valid type name only accept Alphabet letters")]
        public string TypeName { get; set; }
        public int Id { get; set; }
    }
}
