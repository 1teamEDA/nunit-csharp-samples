using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class LibraryManagerTests
{
    [Test]
    public void AddBook_ValidBook_AddsToLibrary()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };

        // Act
        manager.AddBook(book);

        // Assert
        Assert.Contains(book, manager.GetBooks());
    }

    [Test]
    public void AddBook_NullBook_DoesNotAddToLibrary()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();

        // Act
        manager.AddBook(null);

        // Assert
        Assert.IsEmpty(manager.GetBooks());
    }

    [Test]
    public void RemoveBook_ExistingBook_RemovesFromLibrary()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        manager.RemoveBook(book);

        // Assert
        Assert.IsEmpty(manager.GetBooks());
    }

    [Test]
    public void RemoveBook_NonExistingBook_DoesNotRemoveFromLibrary()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        manager.RemoveBook(new Book { Title = "Non Existing Book", Author = "Jane Doe", Articul = "654321" });

        // Assert
        Assert.AreEqual(1, manager.GetBooks().Count);
    }
}

[TestFixture]
public class LibraryStatisticsAnalyzerTests
{
    [Test]
    public void GetBooksByAuthor_ExistingAuthor_ReturnsBooks()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book1 = new Book { Title = "Book 1", Author = "John Doe", Articul = "123456" };
        Book book2 = new Book { Title = "Book 2", Author = "John Doe", Articul = "654321" };
        manager.AddBook(book1);
        manager.AddBook(book2);

        // Act
        List<Book> books = analyzer.GetBooksByAuthor("John Doe");

        // Assert
        Assert.AreEqual(2, books.Count);
    }

    [Test]
    public void GetBooksByAuthor_NonExistingAuthor_ReturnsEmptyList()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book = new Book { Title = "Book 1", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        List<Book> books = analyzer.GetBooksByAuthor("Jane Doe");

        // Assert
        Assert.IsEmpty(books);
    }

    [Test]
    public void GetBookByTitle_ExistingTitle_ReturnsBook()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        Book result = analyzer.GetBookByTitle("Sample Book");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Sample Book", result.Title);
    }

    [Test]
    public void GetBookByTitle_NonExistingTitle_ReturnsNull()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        Book result = analyzer.GetBookByTitle("Non Existing Book");

        // Assert
        Assert.IsNull(result);
    }

    [Test]
    public void GetBookByArticul_ExistingArticul_ReturnsBook()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        Book result = analyzer.GetBookByArticul("123456");

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("123456", result.Articul);
    }

    [Test]
    public void GetBookByArticul_NonExistingArticul_ReturnsNull()
    {
        // Arrange
        LibraryManager manager = new LibraryManager();
        LibraryStatisticsAnalyzer analyzer = new LibraryStatisticsAnalyzer(manager);
        Book book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
        manager.AddBook(book);

        // Act
        Book result = analyzer.GetBookByArticul("654321");

        // Assert
        Assert.IsNull(result);
    }
}
