using Coffee.StockApi.Domain.Contracts;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public interface IStockItemRepository : IRepository<StockItem>
{
    Task<StockItem> FindByIdAsync(long id, CancellationToken cancellationToken = default);
    Task<StockItem> FindBySkuAsync(Sku sku, CancellationToken cancellationToken = default);
}