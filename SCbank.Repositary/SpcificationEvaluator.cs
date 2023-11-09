using Microsoft.EntityFrameworkCore;
using SCbank.Core.Entities;
using SCbank.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Repositary
{
    public class SpcificationEvaluator<T> where T : BaseEntity
    {
        // function take specificarion for entity and then build the dynamic query
        public static IQueryable<T> GetQuary(IQueryable<T> quary, IGenericSpecification<T> specificarion)
        {
            var MyQuary = quary;
            if (specificarion.WhereCondition != null)
                MyQuary = MyQuary.Where(specificarion.WhereCondition);
            MyQuary = specificarion.Includes.Aggregate(MyQuary, (CurrentQuary, ContactPart) => CurrentQuary.Include(ContactPart));
            return MyQuary;
        }
    }
}
