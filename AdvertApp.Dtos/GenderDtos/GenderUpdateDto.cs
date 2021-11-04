using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos.GenderDtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
