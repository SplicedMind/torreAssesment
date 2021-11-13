using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using torreAssesment.ViewModels;

namespace torreAssesment.Repository
{
    public class DataService : IDataService
    {
        private IConfiguration Configuration { get; }

        public DataService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<ProfileVm> GetProfile(string username)
        {
            if (string.IsNullOrWhiteSpace(username))  
                throw new ArgumentException("Username cannot be null or empty");
            
            string bioUrl = Configuration["Endpoints:Bio"];
            if (string.IsNullOrWhiteSpace(bioUrl))
                throw new Exception("Job url not configured");

            using (var client = CreateClient(new Uri(bioUrl)))
            {
                HttpResponseMessage res = await client.GetAsync(username);
                Stream content = await res.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ProfileVm>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<JobsVm> GetJobs(string @params)
        {
            string jobsUrl = Configuration["Endpoints:Opportunities"];
            if (string.IsNullOrWhiteSpace(jobsUrl))
                throw new Exception("Jobs url not configured");

            using (var client = CreateClient(new Uri(jobsUrl)))
            {
                var res = await client.PostAsync("", new StringContent(@params, Encoding.UTF8, "application/json"));
                Stream content = await res.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<JobsVm>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<JobVm> GetJob(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Id cannot be null or empty");

            string jobUrl = Configuration["Endpoints:Opportunity"];
            if (string.IsNullOrWhiteSpace(jobUrl))
                throw new Exception("Job url not configured");

            using (var client = CreateClient(new Uri(jobUrl)))
            {
                var res = await client.GetAsync(id);
                Stream content = await res.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<JobVm>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }

        public async Task<ProfilesVm> GetProfiles(string @params)
        {
            string biosUrl = Configuration["Endpoints:People"];
            if (string.IsNullOrWhiteSpace(biosUrl))
                throw new Exception("Profiles url not configured");

            using (var client = CreateClient(new Uri(biosUrl)))
            {
                var res = await client.PostAsync("", new StringContent(@params, Encoding.UTF8, "application/json"));
                Stream content = await res.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<ProfilesVm>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
        }
                

        private HttpClient CreateClient(Uri uri)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = uri;
            return client;
        }
    }
}
