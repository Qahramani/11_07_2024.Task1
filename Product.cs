namespace _11_07_2024.Generics;
public abstract class Product
{
    public int Id { get; protected set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public decimal TotalIncome { get; protected set; }

    protected Product(string name, decimal price, int count)
    {
        Name = name;
        Price = price;
        Count = count;
    }

    public abstract void Sell();
    public abstract void ShowInfo();

}

