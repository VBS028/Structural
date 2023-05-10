namespace Structural;

interface IStockProxy : IStockDataAdapter
{
    void BuyStock(int quantity);
    void SellStock(int quantity);
}