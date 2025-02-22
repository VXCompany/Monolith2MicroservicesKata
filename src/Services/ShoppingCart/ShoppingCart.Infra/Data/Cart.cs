﻿namespace ShoppingCart.Infra.Data;

public class Cart
{
    public Guid Id { get; set; }
    public string CustomerNumber { get; set; }
    public ICollection<CartItem> Items { get; set; }
    public string ApplicationSource { get; set; } = "ShoppingCartService";
}