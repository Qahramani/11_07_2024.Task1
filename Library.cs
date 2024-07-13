using _11_07_2024.Generics.Exceptions;

namespace _11_07_2024.Generics;

public class Library
{
    public int BookLimit { get; set; }
    public List<Book> Books { get; set; }
    //public decimal LibraryIncome { get; set; }
    public Library(int bookLimit)
    {
        BookLimit = bookLimit;
        Books = new List<Book>();
    }
    public void AddBook(Book book)
    {
        if (Books.Count == BookLimit)
        {
            throw new CapacityLimitException("Kitabxanadaki kitab limitini asirsiniz");
        }
        Books.Add(book);
        Console.WriteLine("Book added succesfully");
    }
    public void GetBookById(int id)
    {
        foreach (var book in Books)
        {
            if (book.Id == id)
            {
                book.ShowInfo();
                return;
            }
        }
        throw new NotFounException("Kitab tapilmadi");
    }
    public List<Book> GetAllBooks()
    {
        return Books;
    }

    public void RemoveById(int id)
    {
        foreach (var book in Books)
        {
            if (book.Id == id)
            {
                Books.Remove(book);
                Console.WriteLine("Book removed succesfully");
                return;
            }
        }
        throw new NotFounException("Kitab tapilmadi");
    }

    public void LibraryIncome()
    {
        decimal income = 0;
        foreach (var book in Books)
        {
            income += book.TotalIncome;
        }
        Console.WriteLine($"Total income: {income}AZN");
    }
}
