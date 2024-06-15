using server.Domain.Abstractions;

namespace server.Domain.Entities;

public sealed class Depot: Entity
{
    public string Name { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Town { get; init; } = string.Empty;
    public string FullAdress { get; init; } = string.Empty;
}