using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Entities
{
    // any class impleneted in database will inhirt from BaseEntity
    public class BaseEntity
    {
        public int Id { get; set; }
    }
}
