using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace torreAssesment.Repository
{
    public class HttpClientHelper<T> : IHttpClientHelper<T>
    {
        public async Task<T> Get(Uri uri, string query)
        {
            using(var client = CreateClient(uri))
            {
                var res = await client.GetAsync(query);
                string resString = await res.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(resString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
        }

        public Task<T> Post(Uri uri, string payload)
        {
            throw new NotImplementedException();
        }

        private HttpClient CreateClient(Uri uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;
            return client;
        }
    }
}
