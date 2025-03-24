using NUnit.Framework;
using System;

namespace LibraryManagement.Tests
{
    [TestFixture]
    public class LibraryManagerTests
    {
        private LibraryManager _libraryManager;
        private Book _book;

        [SetUp]
        public void Setup()
        {
            _libraryManager = new LibraryManager();
            _book = new Book("12345", "Test Book", "Abhimanyu Sogani", 2020);
            _libraryManager.AddBook(_book);
        }

        [Test]
        public void AddBook_ShouldAddSuccessfully()
        {
            var newBook = new Book("67890", "Another Book", "Jane Doe", 2019);
            _libraryManager.AddBook(newBook);

            var retrievedBook = _libraryManager.GetBookByISBN("67890");
            Assert.AreEqual("Another Book", retrievedBook.Title);
        }

        [Test]
        public void AddBook_DuplicateISBN_ShouldThrowException()
        {
            var duplicateBook = new Book("12345", "Duplicate Book", "Abhimanyu Sogani", 2021);
            Assert.Throws<InvalidOperationException>(() => _libraryManager.AddBook(duplicateBook));
        }

        [Test]
        public void GetBookByISBN_ExistingBook_ShouldReturnBook()
        {
            var book = _libraryManager.GetBookByISBN("12345");
            Assert.IsNotNull(book);
            Assert.AreEqual("Test Book", book.Title);
        }

        [Test]
        public void GetBookByISBN_NonExistentBook_ShouldThrowException()
        {
            Assert.Throws<KeyNotFoundException>(() => _libraryManager.GetBookByISBN("99999"));
        }

        [Test]
        public void LendBook_AvailableBook_ShouldMarkAsLent()
        {
            _libraryManager.LendBook("12345");
            var book = _libraryManager.GetBookByISBN("12345");
            Assert.IsFalse(book.IsAvailable);
        }

        [Test]
        public void LendBook_AlreadyLent_ShouldThrowException()
        {
            _libraryManager.LendBook("12345");
            Assert.Throws<InvalidOperationException>(() => _libraryManager.LendBook("12345"));
        }

        [Test]
        public void ReturnBook_BorrowedBook_ShouldMarkAsAvailable()
        {
            _libraryManager.LendBook("12345");
            _libraryManager.ReturnBook("12345");
            var book = _libraryManager.GetBookByISBN("12345");
            Assert.IsTrue(book.IsAvailable);
        }

        [Test]
        public void ReturnBook_NotLentBook_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _libraryManager.ReturnBook("12345"));
        }

        [Test]
        public void RemoveBook_ExistingBook_ShouldRemoveSuccessfully()
        {
            _libraryManager.RemoveBook("12345");
            Assert.Throws<KeyNotFoundException>(() => _libraryManager.GetBookByISBN("12345"));
        }

        [Test]
        public void RemoveBook_NonExistentBook_ShouldThrowException()
        {
            Assert.Throws<KeyNotFoundException>(() => _libraryManager.RemoveBook("99999"));
        }

        [Test]
        public void AddBook_EmptyISBN_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Title", "Author", 2020));
        }

        [Test]
        public void AddBook_FuturePublicationYear_ShouldThrowException()
        {
            int futureYear = DateTime.Now.Year + 1;
            Assert.Throws<ArgumentException>(() => new Book("11111", "Future Book", "Author", futureYear));
        }

        [Test]
        public void GetAllAvailableBooks_ShouldReturnOnlyAvailableBooks()
        {
            var availableBooks = _libraryManager.GetAllAvailableBooks();
            Assert.AreEqual(1, availableBooks.Count);
        }
    }
}
