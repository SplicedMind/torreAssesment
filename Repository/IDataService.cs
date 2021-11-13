using System.Threading.Tasks;
using torreAssesment.ViewModels;

namespace torreAssesment.Repository
{
    public interface IDataService
    {
        Task<ProfileVm> GetProfile(string username);
        Task<ProfilesVm> GetProfiles(string @params);
        Task<JobVm> GetJob(string id);
        Task<JobsVm> GetJobs(string @params);
    }
}
