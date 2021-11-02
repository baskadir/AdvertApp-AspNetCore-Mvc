using AdvertApp.Entities.Abstract;

namespace AdvertApp.Entities.Concrete
{
    // Sağlanan hizmetler ve diğer bilgilerin tutulduğu tablo
    public class About : BaseEntity
    {
        public int Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
