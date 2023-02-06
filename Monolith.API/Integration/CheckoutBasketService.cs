using Monolith.OrderManagement;
using Monolith.ShoppingCart.UseCases.CheckoutBasketUseCase;
using Warehouse.Infra;

namespace Monolith.API.Integration;

public class CheckoutBasketService
{
    private readonly CheckoutBasketUseCase _checkoutBasketUseCase;
    private readonly CreateOrderUseCase _createOrderUseCase;
    private readonly IUnitOfWork _unitOfWork;

    public CheckoutBasketService(CheckoutBasketUseCase checkoutBasketUseCase, CreateOrderUseCase createOrderUseCase, IUnitOfWork unitOfWork)
    {
        _checkoutBasketUseCase = checkoutBasketUseCase;
        _createOrderUseCase = createOrderUseCase;
        _unitOfWork = unitOfWork;
    }
    
    public async Task CheckoutBasket(string customerNumber)
    {
        await _checkoutBasketUseCase.CheckoutBasket(new CheckoutBasketRequest(customerNumber));
        
        _createOrderUseCase.CreateOrder(new CreateOrderRequest());

        await _unitOfWork.SaveChangesAsync();
    }
}