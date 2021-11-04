using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos.AboutDtos
{
    public class AboutUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
