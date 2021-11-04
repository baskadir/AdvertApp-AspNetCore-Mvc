using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos.GenderDtos
{
    public class GenderListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
