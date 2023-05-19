using Coffee.MachineApi.Domain.Models;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public class Item : Entity
{
    public ItemType Type { get; }

    public Item(ItemType type)
    {
        Type = type;
    }
}