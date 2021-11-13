using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torreAssesment.Repository
{
    public interface IRepository<T1, T2>
    {
        Task<T1> Get(T2 query);
        Task<T1> Post(T2 payload);        
    }
}
