using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using server.Domain.Entities;

namespace server.Infrastructure.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.Name).HasColumnType("varchar(50)");
        builder.Property(p => p.TaxDepartment).HasColumnType("varchar(50)");
        builder.Property(p => p.TaxNumber).HasColumnType("varchar(50)");
        builder.Property(p => p.City).HasColumnType("varchar(50)");
        builder.Property(p => p.Town).HasColumnType("varchar(50)");
        builder.Property(p => p.FullAdress).HasColumnType("varchar(50)");
    }
}