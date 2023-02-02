namespace Warehouse.UseCases.ReceiveGoodsUseCase;

public record ReceiveGoodsRequest(IEnumerable<ReceivedGood> ReceivedGoods);

public record ReceivedGood(string Name, int Quality, int SellIn);