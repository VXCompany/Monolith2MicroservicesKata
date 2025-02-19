﻿namespace Warehouse.Infra.Data;

public class StockItem
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ProductCode { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
    public int Count { get; set; }
    public int ReservedCount { get; set; }
    public string ApplicationSource { get; set; } = "Monolith";
}