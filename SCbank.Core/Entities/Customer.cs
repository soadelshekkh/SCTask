using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Entities
{
    //represent Customer table in database 
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public int age { get; set; }
        public string NationalId { get; set; }
        public Address Address { get; set; }
        public int CustomerTypeId { get; set; }
        //navigation property show customer has one type 
        public CustomerType CustomerType { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public DateTime TimeOfCreation { get; set; } 
    }
}
