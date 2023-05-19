using Coffee.MachineApi.Domain.Models;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public class Sku : ValueObject
{
    public long Value { get; }
        
    public Sku(long sku)
    {
        Value = sku;
    }
        
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}