using server.Domain.Abstractions;
using server.Domain.Enums;

namespace server.Domain.Entities;

public sealed class Order: Entity
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public OrderStatusEnum Status { get; set; }= OrderStatusEnum.Pending;
    public List<OrderDetail>? OrderList { get; set; }
}