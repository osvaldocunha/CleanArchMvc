using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class RatesConfiguration : IEntityTypeConfiguration<Rates>
    {
        public void Configure(EntityTypeBuilder<Rates> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.To).HasMaxLength(3).IsRequired();
            builder.Property(p => p.From).HasMaxLength(3).IsRequired();
            builder.Property(p => p.Rate).HasPrecision(10,2).IsRequired();

            builder.HasData(
                new Rates("EUR", "USD", 1.359),
                new Rates("CAD", "EUR", 0.732),
                new Rates("USD", "EUR", 0.736),
                new Rates("EUR", "CAD", .366)
             );
        }
    }
}
