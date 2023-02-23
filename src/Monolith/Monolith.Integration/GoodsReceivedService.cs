using Monolith.Notifications.UseCases.NotifyCustomerUseCase;
using Warehouse.Infra;
using Warehouse.UseCases.ReceiveGoodsUseCase;

namespace Monolith.Integration;

public class GoodsReceivedService
{
    private readonly ReceiveGoodsUseCase _receiveGoodsUseCase;
    private readonly INotifyCustomerUseCase _notifyCustomerUseCase;
    private readonly IUnitOfWork _unitOfWork;

    public GoodsReceivedService(
        ReceiveGoodsUseCase receiveGoodsUseCase,
        INotifyCustomerUseCase notifyCustomerUseCase,
        IUnitOfWork unitOfWork)
    {
        _receiveGoodsUseCase = receiveGoodsUseCase;
        _notifyCustomerUseCase = notifyCustomerUseCase;
        _unitOfWork = unitOfWork;
    }

    public async Task GoodsReceived(ReceiveGoodsRequest receiveGoodsRequest)
    {
        await _receiveGoodsUseCase.ProcessReceivedGoodsAsync(receiveGoodsRequest);
        await _notifyCustomerUseCase.NotifyCustomer(new NotifyCustomerRequest("-1", "Goods have arrived and stocks are updated"));

        await _unitOfWork.SaveChangesAsync();
    }
}