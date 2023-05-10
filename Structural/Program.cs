using Structural;

Stock appleStock = new Stock("AAPL", 100);

IStockDataAdapter adaptedStock = new StockDataAdapter(appleStock);

IStockDecorator decoratedStock = new StockDecorator(adaptedStock);

decoratedStock.DisplayStockDetails();

IStockProxy stockProxy = new StockProxy(appleStock);

stockProxy.BuyStock(50);
stockProxy.SellStock(30);

StockPortfolio portfolio = new StockPortfolio();

portfolio.AddStock(new StockDecorator(new StockDataAdapter(new Stock("GOOGL", 200))));
portfolio.AddStock(new StockDecorator(new StockDataAdapter(new Stock("MSFT", 150))));
portfolio.AddStock(new StockDecorator(new StockDataAdapter(new Stock("AMZN", 300))));

Console.WriteLine($"Portfolio: {portfolio.GetStockName()}");
Console.WriteLine($"Total Quantity: {portfolio.GetStockQuantity()}");

portfolio.RemoveStock(new StockDecorator(new StockDataAdapter(new Stock("GOOGL", 200))));

Console.WriteLine($"Updated Portfolio: {portfolio.GetStockName()}");
Console.WriteLine($"Updated Total Quantity: {portfolio.GetStockQuantity()}");
