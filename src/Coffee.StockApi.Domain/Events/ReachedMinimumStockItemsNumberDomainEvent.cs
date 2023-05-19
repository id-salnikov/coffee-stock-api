using Coffee.StockApi.Domain.AggregationModels;
using Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;
using MediatR;

namespace Coffee.StockApi.Domain.Events;

public class ReachedMinimumStockItemsNumberDomainEvent : INotification
{
    public Sku StockItemSku { get; }
    
    public ReachedMinimumStockItemsNumberDomainEvent(Sku stockItemSku) {
        StockItemSku = stockItemSku;
    }
}