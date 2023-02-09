using Warehouse.Infra;

namespace Monolith.OrderManagement.UseCases.CreateOrderUseCase;

public class CreateOrderUseCase
{
    private readonly MonolithDbContext _monolithDbContext;
    private const double VAT = 0.19;

    public CreateOrderUseCase(MonolithDbContext monolithDbContext)
    {
        _monolithDbContext = monolithDbContext;
    }
    
    public void CreateOrder(CreateOrderRequest request)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
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
        
        
    }
}