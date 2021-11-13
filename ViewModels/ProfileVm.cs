using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torreAssesment.ViewModels
{
    public class ProfileVm
    {
        public BioVm Person { get; set; }
        public IEnumerable<StrenghtVm> Strengths { get; set; }
        public IEnumerable<InterestVm> Interests { get; set; }
    }
}
