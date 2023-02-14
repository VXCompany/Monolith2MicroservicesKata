using Warehouse.Infra;
using Warehouse.Infra.Data;

namespace Monolith.OrderManagement.UseCases.CreateOrderUseCase;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _orderRepository;
    private const double VAT = 0.21;

    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task CreateOrder(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            Status = OrderStatus.Processing,
            CustomerNumber = request.Cart.CustomerNumber,
            TotalPrice = request.Cart.Items.Sum(item => item.Amount * DeterminePrice(item)),
            TotalWithTax = request.Cart.Items.Sum(item => item.Amount * DeterminePrice(item)) * (1 + VAT),
            OrderLines = request.Cart.Items.Select(item => new OrderLine
            {
                Id = Guid.NewGuid(),
                ProductCode = item.ProductCode,
                TotalOrdered = item.Amount,
                Price = DeterminePrice(item)
            }).ToList()
        };

        await _orderRepository.Save(order);
    }

    private double DeterminePrice(CartItem cartItem)
    {
        return cartItem.ProductCode switch
        {
            "NORM-MoonJ" => 1.00,
            "EPIC-Ragnaros" => 1500,
            "TICK-TAFK" => 80,
            "SPOIL-BRIE" => 10,
            _ => throw new InvalidOperationException("unknown product")
        };
    }
}