using Hotels.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context;

        public GenericRepository(DbContext context) => _context = context;

        public async Task<List<T>> GetAll() =>
            await _context.Set<T>().ToListAsync();    

        public async Task<T> GetById(Guid id) =>
           await _context.Set<T>().FindAsync(id);

        public async Task Insert(T entity) =>
           await _context.Set<T>().AddAsync(entity);

        public async Task Update(T entity) =>
           _context.Entry(entity).State = EntityState.Modified;   

        public async Task Delete(Guid id)
        {
            T entity = await _context.Set<T>().FindAsync(id);

            _context.Set<T>().Remove(entity);
        }
           
    }
}
