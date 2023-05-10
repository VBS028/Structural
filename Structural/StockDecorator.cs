namespace Structural;

class StockDecorator : IStockDecorator
{
    private IStockDataAdapter stockDataAdapter;

    public StockDecorator(IStockDataAdapter stockDataAdapter)
    {
        this.stockDataAdapter = stockDataAdapter;
    }

    public string GetStockName()
    {
        return stockDataAdapter.GetStockName();
    }

    public int GetStockQuantity()
    {
        return stockDataAdapter.GetStockQuantity();
    }

    public void DisplayStockDetails()
    {
        Console.WriteLine($"Stock: {GetStockName()}, Quantity: {GetStockQuantity()}");
    }
}