using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;
using server.Domain.Enums;

namespace server.Infrastructure.Configurations;

internal sealed class ProductConfigration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p => p.Type)
            .HasConversion(t => t.Value, 
                value => ProductTypeEnum.FromValue(value));
    }
}