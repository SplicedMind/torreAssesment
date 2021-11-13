using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torreAssesment.Repository
{
    public class BioRepository : IRepository<BioRepository, string>
    {
        private IConfiguration Configuration { get; }
        public BioRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<BioRepository> Get(string query)
        {
            throw new NotImplementedException();
        }

        public Task<BioRepository> Post(string payload)
        {
            throw new NotImplementedException();
        }
    }
}
