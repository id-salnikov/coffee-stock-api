using Coffee.MachineApi.Domain.Models;
using Coffee.StockApi.Domain.Events;

namespace Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

public class StockItem : Entity
{
    public StockItem(Name name, Sku sku, Volume volume, Quantity quantity, Quantity minimalQuantity, Item itemType) {
        Name = name;
        Sku = sku;
        Volume = volume;
        Quantity = quantity;
        MinimalQuantity = minimalQuantity;
        Item = itemType;
    }

    public Name Name { get; }
    public Sku Sku { get; }
    public Volume Volume { get; }
    public Quantity Quantity { get; private set; }
    public Quantity MinimalQuantity { get; }
    public Item Item { get; }

    public void IncreaseQuantity(int valueToIncrease) {
        if (valueToIncrease < 0)
            throw new Exception($"{nameof(valueToIncrease)} less than 0");
        Quantity = new Quantity(this.Quantity.Value + valueToIncrease);
    }
    
    public void GiveOutItems(int valueToGiveOut)
    {
        if (valueToGiveOut < 0)
            throw new Exception($"{nameof(valueToGiveOut)} value is negative");
        if (Quantity.Value < valueToGiveOut)
            throw new Exception("Not enough items");
        Quantity = new Quantity(this.Quantity.Value - valueToGiveOut);
            
        if(Quantity.Value <= MinimalQuantity.Value)
             AddReachedMinimumDomainEvent(Sku);
    }
    private void SetQuantity(Quantity value)
    {
        if (value.Value < 0)
            throw new Exception($"{nameof(value)} value is negative");

        Quantity = value;
    }

    // private void SetMinimalQuantity(QuantityValue value)
    // {
    //     if (value is null)
    //         throw new ArgumentNullException($"{nameof(value)} is null");
    //     if (value.Value is not null && value.Value < 0)
    //         throw new Exception($"{nameof(value)} value is negative");
    //
    //     MinimalQuantity = value;
    // }

    private void AddReachedMinimumDomainEvent(Sku sku)
    {
        var orderStartedDomainEvent = new ReachedMinimumStockItemsNumberDomainEvent(sku);

        this.AddDomainEvent(orderStartedDomainEvent);
    }
}
