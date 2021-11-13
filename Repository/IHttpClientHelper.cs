using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torreAssesment.Repository
{
    interface IHttpClientHelper<T>
    {
        Task<T> Get(Uri uri, string query);
        Task<T> Post(Uri uri, string payload);
    }
}
