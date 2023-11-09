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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {   //you can use .OnDelete(DeleteBehavior.SetNull) to when delete type customers with relationship with this type (typeid set null)
            //here when delete type customers with relationship with this type will deleted also
            builder.HasOne(c => c.CustomerType).WithMany(CType => CType.Customers).HasForeignKey(c => c.CustomerTypeId);
            builder.Property(c => c.age).IsRequired(true);
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.NationalId).IsRequired(true);
            builder.OwnsOne(c => c.Address, NP => NP.WithOwner());
            builder.Property(c => c.PhoneNumber).IsRequired(true);
            builder.Property(c => c.Email).IsRequired(true);
        }
    }
}
