using SCbank.Core.Entities;
using SCbank.Core.Repositories;
using SCbank.Repositary.DbContexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Repositary
{
    //UnitOfWork for repositories
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScBankDbContext context;
        private Hashtable Repositaries;
        public UnitOfWork(ScBankDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Complete()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IGenericRepository<TEntity> Repositary<TEntity>() where TEntity : BaseEntity
        {
            if (Repositaries == null)
                Repositaries = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!Repositaries.ContainsKey(type))
            {
                var repositary = new GenericRepository<TEntity>(context);
                Repositaries.Add(type, repositary);
            }
            return (IGenericRepository<TEntity>)Repositaries[type];
        }
    }
}
