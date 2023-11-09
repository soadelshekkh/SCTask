using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Specifications
{   //class has properties you need to build dynamic query
    public class BaseSpecification<T> : IGenericSpecification<T> where T : BaseEntity
    {
        public BaseSpecification()
        {
                
        }
        public BaseSpecification(Expression<Func<T,bool>> Condition)
        {
            WhereCondition = Condition;       
        }
        // WhereCondition express a where condition in dynamic query Myquery.where(WhereCondition)
        public Expression<Func<T, bool>> WhereCondition { get; set; }
        // Includes express a Includes in dynamic query Myquery.includes(Includes)
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
    }
}
