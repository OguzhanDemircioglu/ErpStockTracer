using server.Domain.Entities;
using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace server.Infrastructure.Context;

public sealed class ApplicationDbContext(DbContextOptions options)
    : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>(options), IUnitOfWork
{
    public DbSet<Customer> Customers { get; init; }
    public DbSet<Depot> Depots { get; init; }
    public DbSet<Product> Products { get; init; }
    public DbSet<Recipe> Recipes { get; init; }
    public DbSet<RecipeDetail> RecipeDetails { get; init; }
    public DbSet<Order> Orders { get; init; }
    public DbSet<OrderDetail> OrderDetails { get; init; }
    public DbSet<Invoice> Invoices { get; init; }
    public DbSet<InvoiceDetail> InvoiceDetails { get; init; }
    public DbSet<StockMovement> StockMovements { get; init; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

        builder.Ignore<IdentityUserLogin<Guid>>();
        builder.Ignore<IdentityRoleClaim<Guid>>();
        builder.Ignore<IdentityUserToken<Guid>>();
        builder.Ignore<IdentityUserRole<Guid>>();
        builder.Ignore<IdentityUserClaim<Guid>>();
    }
}