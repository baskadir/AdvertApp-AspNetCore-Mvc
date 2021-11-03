using AdvertApp.Common.Enums;
using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.SeedData
{
    class GenderDataSeed : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasData(new Gender[] {
                new()
                {
                    Id = (int)GenderType.Male,
                    Definition = GenderType.Male.ToString()
                },
                new()
                {
                    Id = (int)GenderType.Female,
                    Definition = GenderType.Female.ToString()
                },
                new()
                {
                    Id = (int)GenderType.Other,
                    Definition = GenderType.Other.ToString()
                }
            });
        }
    }
}
