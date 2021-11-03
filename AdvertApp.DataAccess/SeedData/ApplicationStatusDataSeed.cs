using AdvertApp.Common.Enums;
using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.SeedData
{
    public class ApplicationStatusDataSeed : IEntityTypeConfiguration<ApplicationStatus>
    {
        public void Configure(EntityTypeBuilder<ApplicationStatus> builder)
        {
            builder.HasData(new ApplicationStatus[]
            {
                new()
                {
                    Id=(int)ApplicationStatusType.Applied,
                    Definition=ApplicationStatusType.Applied.ToString()
                },
                new()
                {
                    Id=(int)ApplicationStatusType.InterviewCall,
                    Definition=ApplicationStatusType.InterviewCall.ToString()
                },
                new()
                {
                    Id=(int)ApplicationStatusType.Negative,
                    Definition=ApplicationStatusType.Negative.ToString()
                },
            });
        }
    }
}
