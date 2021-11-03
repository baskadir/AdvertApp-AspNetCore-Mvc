using AdvertApp.Common.Enums;
using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.SeedData
{
    class AppRoleDataSeed : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new AppRole[] {
                new()
                {
                    Id=(int)RoleType.Admin,
                    Name=RoleType.Admin.ToString()
                },
                new()
                {
                    Id = (int)RoleType.Member,
                    Name=RoleType.Member.ToString()
                }
            });
        }
    }
}
