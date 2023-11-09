using SCbank.Core.Entities;
using SCbank.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Repositories
{
    // interface for GenericRepository class in repository project
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<IEnumerable<T>> GetAll();
        // GetAllSpec get data with includes, filters ... etc using specification pattern to build dynamic query
        Task<IEnumerable<T>> GetAllSpec(IGenericSpecification<T> spec);
        Task<T> GetByIdspec(IGenericSpecification<T> spec);
        Task<T> GetById(int? id);
        Task Create(T entity);
        void update(T entity);
        void delete(T entity);

    }
}
