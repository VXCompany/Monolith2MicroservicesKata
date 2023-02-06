using Monolith.ShoppingCart.Mappers;
using Warehouse.Infra;

namespace Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;

public class AddItemToShoppingCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly CartMapper _cartMapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddItemToShoppingCartUseCase(IShoppingCartRepository shoppingCartRepository, CartMapper cartMapper, IUnitOfWork unitOfWork)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _cartMapper = cartMapper;
        _unitOfWork = unitOfWork;
    }

    public async Task AddItemToShoppingCartAsync(AddItemToShoppingCartRequest request)
    {
        var shoppingCartData = await _shoppingCartRepository.FindForCustomerAsync(request.CustomerNumber);

        Cart cart;
        if (shoppingCartData == null)
        {
            shoppingCartData = new Warehouse.Infra.Data.Cart
            {
                CustomerNumber = request.CustomerNumber,
                Items = new List<Warehouse.Infra.Data.CartItem>()
            };
            cart = new Cart
            {
                CustomerNumber = request.CustomerNumber,
                Items = new List<CartItem>()
            };
        }
        else
        {
            cart = _cartMapper.MapDataToDomain(shoppingCartData);
        }


        cart.AddItemToCart(request.ProductId);

        _cartMapper.MapDomainToData(cart, shoppingCartData);

        await _shoppingCartRepository.Save(shoppingCartData);
        await _unitOfWork.SaveChangesAsync();
    }
}