using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.SeedData
{
    public class AboutDataSeed : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasData(new About[]
            {
                new()
                {
                    Id = 1,
                    Title = "İşe alım danışmanlığı",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed leo vel ipsum efficitur accumsan id eget neque. Nam erat libero, viverra vel nibh at, malesuada pulvinar sapien. ",
                    ImagePath = "https://picsum.photos/id/1014/400/400"
                },
                new()
                {
                    Id = 2,
                    Title = "Dış Kaynak Hizmetler",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed leo vel ipsum efficitur accumsan id eget neque. Nam erat libero, viverra vel nibh at, malesuada pulvinar sapien. ",
                    ImagePath = "https://picsum.photos/id/1031/400/400"
                },
                new()
                {
                    Id = 3,
                    Title = "Eğitim Hizmetleri",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas sed leo vel ipsum efficitur accumsan id eget neque. Nam erat libero, viverra vel nibh at, malesuada pulvinar sapien. ",
                    ImagePath = "https://picsum.photos/id/1025/400/400"
                },
            });
        }
    }
}
