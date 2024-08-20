using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Configurations;

public sealed class ProductionConfigration : IEntityTypeConfiguration<Production>
{
    public void Configure(EntityTypeBuilder<Production> builder)
    {
        builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
    }
}