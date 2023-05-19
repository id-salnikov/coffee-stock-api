using Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;
using Coffee.StockApi.Infrastructure.Commands.GiveOutStockItem;
using MediatR;

namespace Coffee.StockApi.Infrastructure.Handlers.StockItemAggregate;

public class GiveOutStockItemCommandHandler : IRequestHandler<GiveOutStockItemCommand, Unit>
{
    private IStockItemRepository _itemRepository;
    public GiveOutStockItemCommandHandler(IStockItemRepository itemRepository) {
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(GiveOutStockItemCommand request, CancellationToken cancellationToken) {
        var stockItem = await _itemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
        if (stockItem is null) {
            throw new Exception($"Not find with sku {request.Sku}");
        }
        
        stockItem.GiveOutItems(request.Quantity);
        await _itemRepository.UpdateAsync(stockItem, cancellationToken);
        await _itemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        
        return Unit.Value;
    }
}