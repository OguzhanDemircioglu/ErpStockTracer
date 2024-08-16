using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;
using server.Domain.Enums;

namespace server.Infrastructure.Configurations;

public sealed class InvoiceConfigration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.Property(p => p.Type)
            .HasConversion(s => s!.Value, value => InvoiceTypeEnum.FromValue(value));
    }
}