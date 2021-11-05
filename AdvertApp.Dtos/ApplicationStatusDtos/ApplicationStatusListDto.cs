using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos
{
    public class ApplicationStatusListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
