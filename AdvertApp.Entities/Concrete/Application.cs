using AdvertApp.Entities.Abstract;
using System;

namespace AdvertApp.Entities.Concrete
{
    public class Application : BaseEntity
    {
        public int AdvertisementId { get; set; }
        public Advertisement Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ApplicationStatusId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatus MilitaryStatus { get; set; }
        public DateTime? PostponeEndDate { get; set; } // tecil bitiş tarihi 
        public DateTime AppliedDate { get; set; } // ilana başvurulan tarih
        public int WorkExperience { get; set; }
        public string PhotoPath { get; set; }
        public string CvPath { get; set; }
    }
}
