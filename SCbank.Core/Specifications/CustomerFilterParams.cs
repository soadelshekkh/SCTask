using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Specifications
{ // class has properties express values you want filter the data based on it using specification design pattern
    public class CustomerFilterParams
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? CustomerTypeId { get; set; }
    }
}
