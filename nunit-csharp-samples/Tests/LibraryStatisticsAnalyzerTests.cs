using NUnit.Framework;
using System.Collections.Generic;

namespace nunit_csharp_samples.Tests
{
    [TestFixture]
    public class LibraryStatisticsAnalyzerTests
    {
        [Test]
        public void GetBooksByAuthor_ExistingAuthor_ReturnsBooks()
        {
            // Arrange
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book1 = new Book { Title = "Book 1", Author = "John Doe", Articul = "123456" };
            var book2 = new Book { Title = "Book 2", Author = "John Doe", Articul = "654321" };
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
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book = new Book { Title = "Book 1", Author = "John Doe", Articul = "123456" };
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
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
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
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
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
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
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
            var manager = new LibraryManager();
            var analyzer = new LibraryStatisticsAnalyzer(manager);
            var book = new Book { Title = "Sample Book", Author = "John Doe", Articul = "123456" };
            manager.AddBook(book);

            // Act
            Book result = analyzer.GetBookByArticul("654321");

            // Assert
            Assert.IsNull(result);
        }
    }
}
