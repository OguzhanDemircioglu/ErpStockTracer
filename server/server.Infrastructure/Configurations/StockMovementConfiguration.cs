using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Configurations;

internal sealed class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
  public void Configure(EntityTypeBuilder<StockMovement> builder)
  {
    builder.Property(p => p.NumberOfInputs).HasColumnType("decimal(7,2)");
    builder.Property(p => p.NumberOfOutputs).HasColumnType("decimal(7,2)");
    builder.Property(p => p.Price).HasColumnType("money");
  }
}