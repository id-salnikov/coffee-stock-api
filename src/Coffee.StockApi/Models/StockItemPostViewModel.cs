namespace CoffeeStockApi.Models;

public class StockItemPostViewModel
{ 
    public long Sku { get; init; }
    public string Name { get; init; }
    public int StockItemType { get; init; }
    public int Volume { get; init; }
    public int Quantity { get; init; }
    public int MinimalQuantity { get; init; }
}