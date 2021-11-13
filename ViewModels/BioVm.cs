using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace torreAssesment.ViewModels
{
    public class BioVm
    {
        public string ProfessinalHeadline { get; set; }
        public bool Verified { get; set; }
        public float Completion { get; set; }
        public bool ShowPhone { get; set; }
        public FlagsVm Flags { get; set; }
        public int SubjectId { get; set; }
        public string Picture { get; set; }
        public string PictureThumbnail { get; set; }
        public bool HasEmail { get; set; }
        public bool IsTest { get; set; }
        public string SummaryOfBio { get; set; }
        public string PublicId { get; set; }
        public IEnumerable<LinkVm> Links { get; set; }
        public LocationVm Location { get; set; }
        public string Theme { get; set; }
        public string Id { get; set; }
        public bool Claimant { get; set; }
        public string Name { get; set; }
    }
}
