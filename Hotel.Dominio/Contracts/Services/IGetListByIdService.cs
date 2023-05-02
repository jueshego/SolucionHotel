﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels.Domain.Contracts.Services
{
    public interface IGetListByIdService<T> where T : class
    {
        Task<ICollection<T>> GetListByIdService(Guid Id);
    }
}
