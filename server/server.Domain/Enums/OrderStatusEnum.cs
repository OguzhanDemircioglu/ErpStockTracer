﻿using Ardalis.SmartEnum;

namespace server.Domain.Enums;

public sealed class OrderStatusEnum: SmartEnum<OrderStatusEnum>
{
    public static readonly OrderStatusEnum Pending = new("Bekliyor", 1);
    public static readonly OrderStatusEnum RequirementPlanWorked = new("İhtiyaç Planı Çalışıldı", 2);
    public static readonly OrderStatusEnum Completed = new("Complated", 3);
    
    public OrderStatusEnum(string name, int value) : base(name, value)
    {
    }
}