using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Contracts.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(Guid id);

        Task Insert(T entity);

        Task Update(T entity);

        Task Delete(Guid id);
    }
}
