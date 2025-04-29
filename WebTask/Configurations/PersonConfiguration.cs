using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTask.Models;

namespace WebTask.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.F).HasColumnName("f");
            builder.Property(p => p.I).HasColumnName("i");
            builder.Property(p => p.O).HasColumnName("o");
            builder.Property(p => p.BirthDate).HasColumnName("birth_date");
        }
    }
}