using Microsoft.EntityFrameworkCore;
using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Repositary.DbContexts
{
    public class ScBankDbContext : DbContext
    {
        // class for build my Entities classes in database
        public ScBankDbContext(DbContextOptions<ScBankDbContext> Options): base(Options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
