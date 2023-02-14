namespace Warehouse.UseCases.ReceiveGoodsUseCase;

public record ReceiveGoodsRequest(IEnumerable<ReceivedGood> ReceivedGoods);

public record ReceivedGood(string ProductCode, int Quality, int SellIn, int AmountReceived);