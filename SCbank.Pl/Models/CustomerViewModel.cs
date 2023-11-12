using SCbank.Core.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCbank.Pl.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of Employee is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 char")]
        [MinLength(3, ErrorMessage = "min legth is 3 char")]
        [RegularExpression(@"^[a-zA-Z ]{3,50}$", ErrorMessage = "Please enter valid name")]
        public string Name { get; set; }
        [Range(16, 300, ErrorMessage = "Your age should start from 18")]
        public int age { get; set; }
        [RegularExpression(@"^[0-9]{2,25}$", ErrorMessage = "Please enter valid National Id")]
        public string NationalId { get; set; }

        public AddressViewModel Address { get; set; }
        [Required(ErrorMessage = "Please select your type")]
        [ForeignKey("CustomerType")]
        public int? CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage = "please enter vaild Phone number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage ="Enter valid E-mail")]
        public string Email { get; set; }
        public DateTime? TimeOfCreation { get; set; } 
    }
}
