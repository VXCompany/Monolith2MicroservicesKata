namespace Monolith.ShoppingCart.Mappers;

public class CartMapper
{
    private readonly CartItemMapper _cartItemMapper;

    public CartMapper(CartItemMapper cartItemMapper)
    {
        _cartItemMapper = cartItemMapper;
    }
    
    public Cart MapDataToDomain(Warehouse.Infra.Data.Cart cartData)
    {
        return new Cart
        {
            CustomerNumber = cartData.CustomerNumber,
            Items = cartData.Items.Select(item => _cartItemMapper.MapFromData(item)).ToList()
        };
    }

    public void MapDomainToData(Cart cart, Warehouse.Infra.Data.Cart cartData)
    {
        // removing items not possible ;)
        foreach (CartItem item in cart.Items)
        {
            var cartItem = cartData.Items.SingleOrDefault(itemData => itemData.Id == item.Id);
            if (cartItem == null)
            {
                cartItem = new Warehouse.Infra.Data.CartItem { Id = item.Id };
                cartData.Items.Add(cartItem);
            }

            _cartItemMapper.MapDomainToData(item, cartItem);
        }
    }
}