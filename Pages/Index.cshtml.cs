using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torreAssesment.Repository;
using torreAssesment.ViewModels;

namespace torreAssesment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataService DataService;
        public ProfileVm Profile { get; private set; }

        public IndexModel(IDataService dataService)
        {
            DataService = dataService;
        }

        public void OnGet(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                Profile = DataService.GetProfile(username).Result;
            }
        }
    }
}
