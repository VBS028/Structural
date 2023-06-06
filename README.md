
# Stock Management System

This application is a simple console application for managing stocks. It follows the principles of Object-Oriented Design and implements several design patterns like Adapter, Decorator, Proxy, and Composite.

## Classes

The code comprises of several classes and interfaces:

### `Stock`
This class represents a simple stock object, with properties for name and quantity of the stock.

```csharp
class Stock
{
public string Name { get; }
public int Quantity { get; }

    public Stock(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}
```

### `IStockDataAdapter` and `StockDataAdapter` (Adapter Pattern)
This interface, along with the `StockDataAdapter` class, implement the Adapter pattern. The Adapter provides a consistent interface (`IStockDataAdapter`) for interacting with the Stock object.

```csharp
interface IStockDataAdapter
{
string GetStockName();
int GetStockQuantity();
}

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
```

### `IStockDecorator` and `StockDecorator` (Decorator Pattern)
The `IStockDecorator` interface and `StockDecorator` class implement the Decorator pattern. This pattern allows for dynamic addition of functionality to an object. In this case, `DisplayStockDetails` is the added functionality, which displays the name and quantity of the stock.

```csharp
interface IStockDecorator : IStockDataAdapter
{
void DisplayStockDetails();
}

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
```

### `IStockProxy` and `StockProxy` (Proxy Pattern)
The `IStockProxy` interface and `StockProxy` class implement the Proxy pattern. The Proxy provides a controlled interface for interacting with the `Stock` object, in this case, for buying and selling stocks.

```csharp
interface IStockProxy : IStockDataAdapter
{
void BuyStock(int quantity);
void SellStock(int quantity);
}

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
```

### `StockPortfolio` (Composite Pattern)
The `StockPortfolio` class implements the Composite pattern. This pattern allows for treating individual `Stock` objects and compositions of stocks (i.e., the `StockPortfolio`) uniformly.

```csharp
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
```

Each design pattern in use serves a specific purpose in the code:

- Adapter Pattern: This pattern allows classes with incompatible interfaces to work together. It wraps the interface of an object into something that another object can understand.

- Decorator Pattern: This pattern allows a user to add new functionality to an existing object without altering its structure. This type of design pattern comes under structural pattern as this pattern acts as a wrapper to existing class.

- Proxy Pattern: This pattern provides a surrogate or placeholder for another object to control access to it. This pattern is used when we need to create a wrapper to cover the main object’s complexity from the client.

- Composite Pattern: This pattern is used where we need to treat a group of objects in a similar way as a single object. It composes objects in terms of a tree structure to represent part as well as whole hierarchy.
