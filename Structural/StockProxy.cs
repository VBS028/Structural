namespace Structural;

class StockProxy : IStockProxy
{
    private Stock stock;
    private StockDataAdapter stockDataAdapter;

    public StockProxy(Stock stock)
    {
        this.stock = stock;
        this.stockDataAdapter = new StockDataAdapter(stock);
    }

    public string GetStockName()
    {
        return stockDataAdapter.GetStockName();
    }

    public int GetStockQuantity()
    {
        return stockDataAdapter.GetStockQuantity();
    }

    public void BuyStock(int quantity)
    {
        stock.Quantity += quantity;
        Console.WriteLine($"Bought {quantity} shares of {GetStockName()}. Total quantity: {GetStockQuantity()}");
    }

    public void SellStock(int quantity)
    {
        if (quantity > stock.Quantity)
        {
            Console.WriteLine($"Not enough shares of {GetStockName()} to sell.");
            return;
        }

        stock.Quantity -= quantity;
        Console.WriteLine($"Sold {quantity} shares of {GetStockName()}. Total quantity: {GetStockQuantity()}");
    }
}