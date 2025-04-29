using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTask.Models;

namespace WebTask.Configurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.ToTable("passport");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.RPersonId).HasColumnName("r_person_id");
            builder.Property(p => p.Series).HasColumnName("series");
            builder.Property(p => p.Number).HasColumnName("number");
        }
    }
}