using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos
{
    public class ApplicationCreateDto : IDto
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int ApplicationStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime? PostponeEndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
        public DateTime AppliedDate { get; set; }
        public string PhotoPath { get; set; }
    }
}
