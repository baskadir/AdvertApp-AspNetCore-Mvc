using AdvertApp.Dtos.AdvertisementDtos;
using AdvertApp.Dtos.AppUserDtos;
using AdvertApp.Dtos.Interfaces;
using AdvertApp.Dtos.MilitaryStatusDtos;
using System;

namespace AdvertApp.Dtos.ApplicationDtos
{
    public class ApplicationListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public DateTime? PostponeEndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
        public DateTime AppliedDate { get; set; }
        public string PhotoPath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
