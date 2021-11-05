using AdvertApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertApp.Dtos
{
    public class ApplicationUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
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
