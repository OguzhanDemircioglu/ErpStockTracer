using server.Domain.Abstractions;

namespace server.Domain.Entities;

public sealed class RecipeDetail:Entity
{
    public Guid RecipeId { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public Double Quantity { get; set; }
}