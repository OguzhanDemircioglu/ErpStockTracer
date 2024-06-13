using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;
using server.Domain.Enums;

namespace server.Infrastructure.Configurations;

public sealed class OrderConfigration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(p => p.OrderNumber).HasColumnType("varchar(16)");
        builder.Property(p => p.Status)
            .HasConversion(s => s.Value, value => OrderStatusEnum.FromValue(value));
    }
}