namespace Monolith.ShoppingCart;

public class Cart
{
    public string CustomerNumber { get; set; }
    public ICollection<CartItem> Items { get; set; }

    // TODO: This might be a candidate for decoupling contexts on database level. ProductId => Foreign key type? Maybe something like a productCode?
    public void AddItemToCart(Guid productId)
    {
        var item = Items.FirstOrDefault(item => item.ProductId == productId);
        if (item == null)
        {
            item = new CartItem
            {
                ProductId = productId,
                Amount = 1,
                Id = Guid.NewGuid()
            };
            Items.Add(item);
        }
        else
        {
            item.Amount++;
        }
    }
}