using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Configurations;

public class DepotConfiguration: IEntityTypeConfiguration<Depot>
{
    public void Configure(EntityTypeBuilder<Depot> builder)
    {
        builder.Property(p => p.Name).HasColumnType("varchar(50)");
        builder.Property(p => p.City).HasColumnType("varchar(50)");
        builder.Property(p => p.Town).HasColumnType("varchar(50)");
        builder.Property(p => p.FullAdress).HasColumnType("varchar(50)");
    }
}