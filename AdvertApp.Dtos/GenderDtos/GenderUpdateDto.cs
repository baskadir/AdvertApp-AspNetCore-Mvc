using AdvertApp.Dtos.Interfaces;

namespace AdvertApp.Dtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
