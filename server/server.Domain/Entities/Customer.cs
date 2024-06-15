using server.Domain.Abstractions;

namespace server.Domain.Entities;

public sealed class Customer: Entity
{
    public string Name { get; init; } = string.Empty;
    public string TaxDepartment { get; init; } = string.Empty;
    public string TaxNumber { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string Town { get; init; } = string.Empty;
    public string FullAdress { get; init; } = string.Empty;
}