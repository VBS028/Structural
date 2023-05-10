namespace Structural;

public class Stock
{
    public string Name { get; }
    public int Quantity { get; set; }

    public Stock(string name, int quantity)
    {
        Name = name;
        Quantity = quantity;
    }
}