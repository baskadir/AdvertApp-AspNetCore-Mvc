using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos
{
    public class AdvertisementUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
    }
}
