using Monolith.Notifications;
using Warehouse.Infra;
using Warehouse.UseCases.ReceiveGoodsUseCase;

namespace Monolith.Integration;

public class GoodsReceivedService
{
    private readonly ReceiveGoodsUseCase _receiveGoodsUseCase;
    private readonly INotifier _notifier;
    private readonly IUnitOfWork _unitOfWork;

    public GoodsReceivedService(
        ReceiveGoodsUseCase receiveGoodsUseCase,
        INotifier notifier,
        IUnitOfWork unitOfWork)
    {
        _receiveGoodsUseCase = receiveGoodsUseCase;
        _notifier = notifier;
        _unitOfWork = unitOfWork;
    }

    public async Task GoodsReceived(ReceiveGoodsRequest receiveGoodsRequest)
    {
        await _receiveGoodsUseCase.ProcessReceivedGoodsAsync(receiveGoodsRequest);
        await _notifier.NotifyCustomer(new NotifyCustomerRequest("-1", "Goods have arrived and stocks are updated"));

        await _unitOfWork.SaveChangesAsync();
    }
}