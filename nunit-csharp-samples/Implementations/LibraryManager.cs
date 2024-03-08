using System;
using System.Collections.Generic;

public interface ILibraryManager
{
    void AddBook(Book book);
    void RemoveBook(Book book);
}

public class LibraryManager : ILibraryManager
{
    private List<Book> books;

    public LibraryManager()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        if (book != null && !string.IsNullOrEmpty(book.Articul)) // Check for Articul existence
        {
            // Check if the book with the same Articul already exists
            if (books.Any(b => b.Articul == book.Articul))
            {
                Console.WriteLine($"Book with Articul '{book.Articul}' already exists in the library.");
            }
            else
            {
                books.Add(book);
                Console.WriteLine($"Book '{book.Title}' added to the library.");
            }
        }
        else
        {
            Console.WriteLine("Invalid book or Articul is missing.");
        }
    }

    public void RemoveBook(Book book)
    {
        if (book != null && books.Contains(book))
        {
            books.Remove(book);
            Console.WriteLine($"Book '{book.Title}' removed from the library.");
        }
        else
        {
            Console.WriteLine("Book not found in the library or is null.");
        }
    }
}