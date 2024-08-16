﻿using Ardalis.SmartEnum;

namespace server.Domain.Enums;

public sealed class InvoiceTypeEnum(string name, int value) : SmartEnum<InvoiceTypeEnum>(name, value)
{
    public static readonly InvoiceTypeEnum Purchase = new("Alış Faturası", 1);
    public static readonly InvoiceTypeEnum Sales = new("Satış Faturası", 2);
}