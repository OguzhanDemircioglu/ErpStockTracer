﻿using server.Domain.Abstractions;
using server.Domain.Enums;

namespace server.Domain.Entities;

public sealed class Product :Entity
{
    public string Name { get; set; } = string.Empty;
    public ProductTypeEnum Type { get; set; } = ProductTypeEnum.Product;
}