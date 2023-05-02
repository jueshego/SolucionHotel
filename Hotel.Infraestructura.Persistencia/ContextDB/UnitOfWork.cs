using Hotels.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Infrastructure.ContextDB
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context) => _context = context;

        public Task<int> SaveAllChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
