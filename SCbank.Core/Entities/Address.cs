using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Entities
{
    // Not implemented in database it is only represent customer address
    public class Address
    {
        public Address()
        {

        }
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
