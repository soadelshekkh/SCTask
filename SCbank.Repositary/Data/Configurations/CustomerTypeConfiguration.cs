using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Repositary.Data.Configurations
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            //you can use .OnDelete(DeleteBehavior.SetNull) to when delete type, customers with relationship with this type (typeid set null)
            builder.HasMany(c => c.Customers).WithOne(CType => CType.CustomerType).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
