using _11_07_2024.Generics.Exceptions;
using System.Globalization;

namespace _11_07_2024.Generics;

public class Book : Product
{
    private static int _id;
    public string AuthorName { get; set; }
    public int PageCount { get; set; }

    public Book(string name, decimal price, int count, string author, int pageCount): base(name, price,count)
    {
        AuthorName = author;
        PageCount = pageCount;
        Id = ++_id;
    }
    public override void Sell()
    {
        if(Count == 0)
        {
            throw new ProductCountIsZeroException("Bu mehsuldan qalmayib");
        }
        Count--;
        TotalIncome += Price;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"Name:{Name}, Author:{AuthorName}, Page Count:{PageCount}, Price:{Price}AZN, Count:{Count}, Id:{Id}");
    }
}
