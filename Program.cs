using _11_07_2024.Generics.Exceptions;

namespace _11_07_2024.Generics;

public class Program
{
    static void Main(string[] args)
    {
        Library library = new Library(100);
    restartMenu:
        Console.Clear();
        Console.WriteLine("----- Menu -----");
        Console.Write("[1] Add Book\n" +
            "[2] Remove book\n" +
            "[3] Get book by Id\n" +
            "[4] Get all books\n" +
            "[5] Sell book\n" +
            "[6] Get total income\n" +
            "[0] Exit\n" +
            ">>>");
        string option = Console.ReadLine();
        try
        {
            switch (option)
            {
                case "1":
                    Console.Write("Book name: ");
                    string name = Console.ReadLine().Trim();
                    Console.Write("Author: ");
                    string author = Console.ReadLine().Trim();
                    Console.Write("Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());
                    Console.Write("Book count: ");
                    int count = int.Parse(Console.ReadLine());
                    Console.Write("Page count: ");
                    int pageCount = int.Parse((Console.ReadLine()));
                    library.AddBook(new Book(name, price, count, author, pageCount));

                    Console.ReadLine();
                    goto restartMenu;
                case "2":
                    Console.WriteLine("----- Books list -----");
                    foreach (var book in library.GetAllBooks())
                    {
                        book.ShowInfo();
                    }
                    Console.Write("Id of book that you want remove: ");
                    int idRemove = int.Parse(Console.ReadLine());
                    library.RemoveById(idRemove);

                    Console.ReadLine();
                    goto restartMenu;
                case "3":
                    Console.Write("Book Id: ");
                    int idGet = int.Parse(Console.ReadLine());
                    library.GetBookById(idGet);

                    Console.ReadLine();
                    goto restartMenu;
                case "4":
                    Console.WriteLine("----- Books list -----");
                    foreach (var book in library.GetAllBooks())
                    {
                        book.ShowInfo();
                    }

                    Console.ReadLine();
                    goto restartMenu;
                case "5":
                    Console.Write("Id of book that you want to sell: ");
                    int idSell = int.Parse(Console.ReadLine());

                    library.GetBookById(idSell);
                    foreach (var book in library.Books)
                    {
                        if (idSell == book.Id)
                        {
                            book.Sell();
                            Console.WriteLine($"The book \"{book.Name}\" sold successfully");
                            break;
                        }
                    }

                    Console.ReadLine();
                    goto restartMenu;
                case "6":
                    library.LibraryIncome();

                    Console.ReadLine();
                    goto restartMenu;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    goto restartMenu;
            }
        }
        catch (NotFounException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            goto restartMenu;
        }
        catch (CapacityLimitException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            goto restartMenu;
        }
        catch (ProductCountIsZeroException ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            goto restartMenu;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
            goto restartMenu;
        }

    }
}
