using MediatR;

namespace Coffee.StockApi.Infrastructure.Commands.GiveOutStockItem;

public class GiveOutStockItemCommand : IRequest<Unit>
{
    public long Sku { get; set; }
    public int Quantity { get; set; }
}