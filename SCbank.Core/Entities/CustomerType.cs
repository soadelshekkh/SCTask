using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Entities
{
    //represent customer type table in database
    //craete table for customer type because in the future you can add more information about this type
    public class CustomerType : BaseEntity
    {
        public string TypeName { get; set; }
        //navigation property show customer type has many Customers
        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer> ();
    }
}
