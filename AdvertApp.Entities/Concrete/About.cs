using AdvertApp.Entities.Abstract;

namespace AdvertApp.Entities.Concrete
{
    // Sağlanan hizmetler ve diğer bilgilerin tutulduğu tablo
    public class About : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
