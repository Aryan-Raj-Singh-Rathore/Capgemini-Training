using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    public class LibraryManager
    {
        private readonly Dictionary<string, Book> _books = new Dictionary<string, Book>();

        public void AddBook(Book book)
        {
            if (_books.ContainsKey(book.ISBN))
                throw new InvalidOperationException("Book with the same ISBN already exists.");

            _books[book.ISBN] = book;
        }

        public void RemoveBook(string isbn)
        {
            if (!_books.ContainsKey(isbn))
                throw new KeyNotFoundException("Book not found.");

            _books.Remove(isbn);
        }

        public Book GetBookByISBN(string isbn)
        {
            return _books.TryGetValue(isbn, out var book) ? book : throw new KeyNotFoundException("Book not found.");
        }

        public void LendBook(string isbn)
        {
            if (!_books.ContainsKey(isbn))
                throw new KeyNotFoundException("Book not found.");

            if (!_books[isbn].IsAvailable)
                throw new InvalidOperationException("Book is already lent out.");

            _books[isbn].IsAvailable = false;
        }

        public void ReturnBook(string isbn)
        {
            if (!_books.ContainsKey(isbn))
                throw new KeyNotFoundException("Book not found.");

            if (_books[isbn].IsAvailable)
                throw new InvalidOperationException("Book is already available.");

            _books[isbn].IsAvailable = true;
        }

        public List<Book> GetAllAvailableBooks()
        {
            return _books.Values.Where(b => b.IsAvailable).ToList();
        }
    }
}
