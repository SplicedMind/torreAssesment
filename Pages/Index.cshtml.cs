using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using torreAssesment.Repository;

namespace torreAssesment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDataService DataService;

        public IndexModel(IDataService dataService)
        {
            DataService = dataService;
        }

        public async void OnGet([FromQuery] string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                var res = await DataService.GetProfile(username);
            }
            
        }
    }
}
