using Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;
using Coffee.StockApi.Infrastructure.Commands.CreateStockItem;
using MediatR;

namespace Coffee.StockApi.Infrastructure.Handlers.StockItemAggregate;

public class CreateStockItemCommandHandler : IRequestHandler<CreateStockItemCommand, int>
{
    private IStockItemRepository _itemRepository;
    public CreateStockItemCommandHandler(IStockItemRepository itemRepository) {
        _itemRepository = itemRepository;
    }
    
    public async Task<int> Handle(CreateStockItemCommand request, CancellationToken cancellationToken) {
        var stockInDb = await _itemRepository.FindBySkuAsync(new Sku(request.Sku), cancellationToken);
        if (stockInDb is not null)
            throw new Exception($"Stock item with sku {request.Sku} already exist");
        
        var newStockItem = new StockItem(
            new Name(request.Name),
            new Sku(request.Sku),
            new Volume(request.Volume),
            new Quantity(request.Quantity),
            new Quantity(request.MinimalQuantity),
            new Item(ItemType
                .GetAll<ItemType>()
                .FirstOrDefault(it => it.Id.Equals(request.StockItemType)))
        );
        var createResult = await _itemRepository.CreateAsync(newStockItem, cancellationToken);
        await _itemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return createResult.Id;
    }
}