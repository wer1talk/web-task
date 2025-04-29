using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebTask.Models;

namespace WebTask.Configurations
{
    public class DebtConfiguration : IEntityTypeConfiguration<Debt>
    {
        public void Configure(EntityTypeBuilder<Debt> builder) // Наиль, спасибо!
        {
            builder.ToTable("debt");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id).HasColumnName("id"); // перобразовываем snake_case в PascalCase
            builder.Property(d => d.RPersonId).HasColumnName("r_person_id");
            builder.Property(d => d.ContractNumber).HasColumnName("contract_number");
            builder.Property(d => d.ContractDt).HasColumnName("contract_dt");
            builder.Property(d => d.DebtSum).HasColumnName("debt_sum");
        }
    }
}
