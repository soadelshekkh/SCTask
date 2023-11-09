using SCbank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCbank.Core.Repositories
{
    // unitOfWork interface for unitOfwork class in repository project
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repositary<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}
