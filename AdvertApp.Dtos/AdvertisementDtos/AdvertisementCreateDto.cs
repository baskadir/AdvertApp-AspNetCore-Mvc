using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos
{
    public class AdvertisementCreateDto : IDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
    }
}
