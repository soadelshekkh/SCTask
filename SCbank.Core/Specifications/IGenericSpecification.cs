using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Specifications
{       // interface for basespecification 
    public interface IGenericSpecification<T> where T : BaseEntity
    {
        public Expression<Func<T,bool>> WhereCondition { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}
