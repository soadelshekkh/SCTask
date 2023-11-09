using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Specifications
{
    // class give where condition and includes values to BaseSpecification<customer> class
    public class CustomerSpectification : BaseSpecification<Customer> 
    {
        public CustomerSpectification(CustomerFilterParams Params):base(
            c =>
                 (!Params.DateFrom.HasValue || c.TimeOfCreation >= Params.DateFrom) &&
                 (!Params.DateTo.HasValue || c.TimeOfCreation <= Params.DateTo.Value) &&
                 (!Params.CustomerTypeId.HasValue || Params.CustomerTypeId.Value == c.CustomerTypeId)
            )
        {
            Includes.Add(c => c.CustomerType);
        }
        public CustomerSpectification()
        {
            Includes.Add(c => c.CustomerType);
        }
        public CustomerSpectification(int? id): base(c => c.Id == id)
        {
            Includes.Add(c => c.CustomerType);
        }
    }

}
