using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
