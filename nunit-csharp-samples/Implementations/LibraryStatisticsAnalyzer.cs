using System.Collections.Generic;

public class LibraryStatisticsAnalyzer
{
    private readonly LibraryManager _manager;

    public LibraryStatisticsAnalyzer(LibraryManager manager)
    {
        _manager = manager;
    }
    
    /// <summary>
    /// Gets books by author.
    /// </summary>
    /// <param name="author">Book author.</param>
    /// <returns>List of books by the specified author.</returns>
    public List<Book> GetBooksByAuthor(string author)
    {
        List<Book> booksByAuthor = new List<Book>();
        foreach (Book book in _manager.GetBooks())
        {
            if (book.Author == author)
            {
                booksByAuthor.Add(book);
            }
        }
        return booksByAuthor;
    }
    
    /// <summary>
    /// Gets book by title.
    /// </summary>
    /// <param name="title">Book title.</param>
    /// <returns>Book with the specified title.</returns>
    public Book GetBookByTitle(string title)
    {
        foreach (Book book in _manager.GetBooks())
        {
            if (book.Title == title)
            {
                return book;
            }
        }
        return null;
    }

    /// <summary>
    /// Gets book by articul.
    /// </summary>
    /// <param name="articul">Book articul.</param>
    /// <returns>Book with the specified articul.</returns>
    public Book GetBookByArticul(string articul)
    {
        foreach (Book book in _manager.GetBooks())
        {
            if (book.Articul == articul)
            {
                return book;
            }
        }
        return null;
    }
}
