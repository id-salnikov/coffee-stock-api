using Coffee.StockApi.Domain.AggregationModels;
using Coffee.StockApi.Domain.AggregationModels.StockItemAggregate;

namespace Coffee.StockApi.Domain.Tests;

public class StockItemTests
{
    private StockItem _item;
    public StockItemTests() {
        _item = new StockItem(
            new Name("Coffee"),
            new Sku(1),
            new Volume(1000),
            new Quantity(5),
            new Quantity(2),
            new Item(ItemType.Coffee)
        );
    }
    [Fact]
    public void StockItemNewInstanceSuccess() {
        var name = "Coffee";
        
        var item = new StockItem(
            new Name(name),
            new Sku(1),
            new Volume(1000),
            new Quantity(5),
            new Quantity(2),
            new Item(ItemType.Coffee)
        );
        
        Assert.Equal(name, item.Name.Value);
    }

    [Fact]
    public void IncreaseQuantityValueSuccess() {
        var valueToIncrease = 10;
        var expectedValue = valueToIncrease + _item.Quantity.Value;
        
        _item.IncreaseQuantity(valueToIncrease);
        
        Assert.Equal(expectedValue, _item.Quantity.Value);
    }

    [Fact]
    public void IncreaseQuantityValueNegative() {
        var valueToIncrease = -10;
        
        var increase = () => _item.IncreaseQuantity(valueToIncrease);

        Assert.Throws<Exception>(increase);
    }
}