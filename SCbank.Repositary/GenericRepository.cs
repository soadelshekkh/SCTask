using Microsoft.EntityFrameworkCore;
using SCbank.Core.Entities;
using SCbank.Core.Repositories;
using SCbank.Core.Specifications;
using SCbank.Repositary.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Repositary
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // class to Update, get, delete, and create data in database
        private readonly ScBankDbContext context;

        public GenericRepository(ScBankDbContext context)
        {
            this.context = context;
        }
        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public void update(T entity)
        {
            context.Set<T>().Update(entity);
            context.SaveChanges();  
        }

        public void delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        private IQueryable<T> BuildQuary(IGenericSpecification<T> spec)
        {
            return SpcificationEvaluator<T>.GetQuary(context.Set<T>(), spec);
        }
        public async Task<IEnumerable<T>> GetAllSpec(IGenericSpecification<T> spec)
        {
            return await BuildQuary(spec).ToListAsync();
        }

        public async Task<T> GetByIdspec(IGenericSpecification<T> spec)
        {
            return await BuildQuary(spec).FirstOrDefaultAsync();
        }
    }
}
