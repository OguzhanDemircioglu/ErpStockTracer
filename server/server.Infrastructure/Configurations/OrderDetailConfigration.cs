using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Configurations;

public sealed class OrderDetailConfigration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasOne(p => p.Product)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Price).HasColumnType("money");
        builder.Property(p => p.Quantity).HasColumnType("decimal(7,2)");
    }
}