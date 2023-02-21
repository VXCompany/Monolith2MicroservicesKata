using Monolith.Notifications.UseCases.NotifyCustomerUseCase;
using Monolith.OrderManagement.UseCases.CreateOrderUseCase;
using Monolith.ShoppingCart.UseCases.CheckoutBasketUseCase;
using Warehouse.Infra;

namespace Monolith.Integration;

public class CheckoutBasketService
{
    private readonly CheckoutBasketUseCase _checkoutBasketUseCase;
    private readonly CreateOrderUseCase _createOrderUseCase;
    private readonly NotifyCustomerUseCase _notifyCustomerUseCase;
    private readonly IUnitOfWork _unitOfWork;

    public CheckoutBasketService(CheckoutBasketUseCase checkoutBasketUseCase,
        CreateOrderUseCase createOrderUseCase,
        NotifyCustomerUseCase notifyCustomerUseCase,
        IUnitOfWork unitOfWork)
    {
        _checkoutBasketUseCase = checkoutBasketUseCase;
        _createOrderUseCase = createOrderUseCase;
        _notifyCustomerUseCase = notifyCustomerUseCase;
        _unitOfWork = unitOfWork;
    }
    
    public async Task CheckoutBasket(string customerNumber)
    {
        var checkedOutBasket = await _checkoutBasketUseCase.CheckoutBasket(new CheckoutBasketRequest(customerNumber));
        
        await _createOrderUseCase.CreateOrder(new CreateOrderRequest(checkedOutBasket.CheckedOutCart));

        await _notifyCustomerUseCase.NotifyCustomer(new NotifyCustomerRequest(customerNumber, "Order created"));
        
        await _unitOfWork.SaveChangesAsync();
    }
}