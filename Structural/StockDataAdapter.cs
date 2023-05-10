namespace Structural;

class StockDataAdapter : IStockDataAdapter
{
    private Stock stock;

    public StockDataAdapter(Stock stock)
    {
        this.stock = stock;
    }

    public string GetStockName()
    {
        return stock.Name;
    }

    public int GetStockQuantity()
    {
        return stock.Quantity;
    }
}