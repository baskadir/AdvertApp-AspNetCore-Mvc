using AdvertApp.Common.Enums;
using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.SeedData
{
    public class MilitaryStatusDataSeed : IEntityTypeConfiguration<MilitaryStatus>
    {
        public void Configure(EntityTypeBuilder<MilitaryStatus> builder)
        {
            builder.HasData(new MilitaryStatus[] {
                new()
                {
                    Id = (int)MilitaryStatusType.Completed,
                    Definition = MilitaryStatusType.Completed.ToString()
                },
                new()
                {
                    Id = (int)MilitaryStatusType.Postpone,
                    Definition = MilitaryStatusType.Postpone.ToString()
                },
                new()
                {
                    Id = (int)MilitaryStatusType.Exempt,
                    Definition = MilitaryStatusType.Exempt.ToString()
                },
            });
        }
    }
}
