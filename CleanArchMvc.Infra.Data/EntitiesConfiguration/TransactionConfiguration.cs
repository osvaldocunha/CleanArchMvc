using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.Sku);
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.Currency).HasMaxLength(3).IsRequired();

            builder.HasData(
            new Transaction("T2006", 10.00, "USD"),
            new Transaction("M2007", 34.57, "CAD"),
            new Transaction("R2008", 17.95, "USD"),
            new Transaction("T2006", 7.63, "EUR"),
            new Transaction("B2009", 21.23, "USD")
          );
        }
    }
}
