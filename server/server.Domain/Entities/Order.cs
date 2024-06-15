using server.Domain.Abstractions;
using server.Domain.Enums;

namespace server.Domain.Entities;

public sealed class Order: Entity
{
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int OrderNumber { get; set; }
    public int OrderNumberYear { get; set; }
    public string OrderPrefix => setPrefix();
    public DateOnly OrderDate { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public OrderStatusEnum Status { get; set; }= OrderStatusEnum.Pending;
    public List<OrderDetail>? Details { get; set; }

    public string setPrefix()
    {
      string initprefix = "TS";

      string initString = initprefix + OrderNumberYear + OrderNumber;
      int targetLength = 16;
      int missingLength = targetLength - initString.Length;
      
      return initprefix 
             + OrderNumber
             + new string('0',missingLength) 
             + OrderNumberYear;
    }

}