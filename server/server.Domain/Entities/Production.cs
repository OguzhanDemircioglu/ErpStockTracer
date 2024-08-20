using server.Domain.Abstractions;

namespace server.Domain.Entities;

public sealed class Production: Entity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
}