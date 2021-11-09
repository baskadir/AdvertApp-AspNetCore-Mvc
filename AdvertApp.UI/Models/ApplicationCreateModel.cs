using AdvertApp.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace AdvertApp.UI.Models
{
    public class ApplicationCreateModel
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int ApplicationStatusId { get; set; } = (int)ApplicationStatusType.Applied;
        public int MilitaryStatusId { get; set; }
        public DateTime? PostponeEndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }
        public DateTime AppliedDate { get; set; } = DateTime.Now;
        public IFormFile PhotoFile { get; set; }
    }
}
