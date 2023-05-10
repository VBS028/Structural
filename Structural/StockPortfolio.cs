namespace Structural;

class StockPortfolio : IStockDataAdapter
{
    private List<IStockDataAdapter> stocks;

    public StockPortfolio()
    {
        stocks = new List<IStockDataAdapter>();
    }

    public void AddStock(IStockDataAdapter stock)
    {
        stocks.Add(stock);
    }

    public void RemoveStock(IStockDataAdapter stock)
    {
        stocks.Remove(stock);
    }

    public string GetStockName()
    {
        return string.Join(", ", stocks.Select(s => s.GetStockName()));
    }

    public int GetStockQuantity()
    {
        return stocks.Sum(s => s.GetStockQuantity());
    }
}