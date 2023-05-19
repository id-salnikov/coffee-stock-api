using Coffee.MachineApi.Domain.Models;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public class ItemType : Enumeration
{
    public static ItemType Coffee = new(1, nameof(Coffee));
    public static ItemType Milk = new(2, nameof(Milk));
    public static ItemType Sugar = new(3, nameof(Sugar));
    
    public ItemType(int id, string name) : base(id, name)
    {
    }
}