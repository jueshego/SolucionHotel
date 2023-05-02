using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Contracts.Services
{
    public  interface IGetByIdService<T> where T : class
    {
        Task<T> GetById(Guid Id);
    }
}
