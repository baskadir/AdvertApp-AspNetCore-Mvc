using AdvertApp.Dtos.Interfaces;
using System;

namespace AdvertApp.Dtos.AboutDtos
{
    public class AboutListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
