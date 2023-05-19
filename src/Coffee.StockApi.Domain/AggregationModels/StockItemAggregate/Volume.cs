using Coffee.MachineApi.Domain.Models;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public class Volume : ValueObject
{
    public Volume(int value)
    {
        Value = value;
    }

    public int Value { get; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}