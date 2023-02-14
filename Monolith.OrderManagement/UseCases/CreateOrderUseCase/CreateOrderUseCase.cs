using Warehouse.Infra;

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
            TotalPrice = request.Cart.Items.Sum(item => item.Amount),
            TotalWithTax = request.Cart.Items.Sum(item => item.Amount) * (1 + VAT),
            OrderLines = request.Cart.Items.Select(item => new OrderLine
            {
                Id = Guid.NewGuid(),
                ProductCode = item.ProductId.ToString(),
                Price = item.Amount,
                TotalOrdered = item.Amount
            }).ToList()
        };

        await _orderRepository.Save(order);
    }
}