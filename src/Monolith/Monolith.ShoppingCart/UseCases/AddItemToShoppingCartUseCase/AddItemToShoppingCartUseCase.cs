using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Monolith.ShoppingCart.UseCases.AddItemToShoppingCartUseCase;

public class AddItemToShoppingCartUseCase
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddItemToShoppingCartUseCase(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task AddItemToShoppingCartAsync(AddItemToShoppingCartRequest request)
    {
        var cart = await _shoppingCartRepository.FindForCustomerAsync(request.CustomerNumber);

        if (cart == null)
        {
            cart = new Cart
            {
                CustomerNumber = request.CustomerNumber,
                Items = new List<CartItem>()
            };
        }

        var item = cart.Items.FirstOrDefault(item => item.ProductCode == request.ProductCode);
        if (item == null)
        {
            item = new CartItem
            {
                ProductCode = request.ProductCode,
                Amount = 1,
                Id = Guid.NewGuid()
            };
            cart.Items.Add(item);
        }
        else
        {
            item.Amount++;
        }

        await _shoppingCartRepository.Save(cart);
        await _unitOfWork.SaveChangesAsync();
    }
}