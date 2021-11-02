using AdvertApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvertApp.DataAccess.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasIndex(x =>
            new
            {
                x.AdvertisementId,
                x.AppUserId
            }).IsUnique();

            builder.Property(x => x.CvPath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(X => X.PhotoPath).HasMaxLength(500).IsRequired();

            //Relations
            builder.HasOne(x => x.Advertisement).WithMany(x => x.Applications).HasForeignKey(x => x.AdvertisementId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Applications).HasForeignKey(x => x.AppUserId);
            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.Applications).HasForeignKey(x => x.MilitaryStatusId);
            builder.HasOne(x => x.ApplicationStatus).WithMany(x => x.Applications).HasForeignKey(x => x.ApplicationStatusId);
        }
    }
}
