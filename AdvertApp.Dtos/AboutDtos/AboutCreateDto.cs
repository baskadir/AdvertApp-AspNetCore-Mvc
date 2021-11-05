using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos
{
    public class AboutCreateDto : IDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
