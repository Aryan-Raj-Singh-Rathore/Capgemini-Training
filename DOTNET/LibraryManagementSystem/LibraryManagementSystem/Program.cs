using System;
using System.Collections.Generic;

public class Book
{
   
    private string isbn;
    private string title;
    private string author;
    private bool available;

    
    public string ISBN
    {
        get { return isbn; }
        set { isbn = value; }
    }

    public string Title
    {
        get { return title; }
        set { title = value; }
    }

    public string Author
    {
        get { return author; }
        set { author = value; }
    }

    public bool Available
    {
        get { return available; }
        set { available = value; }
    }
}

public class Library
{
  
    private List<Book> books = new List<Book>();

  
    public void AddBook(Book book)
    {
        books.Add(book);
    }


    public bool RemoveBook(string isbn)
    {
        Book bookToRemove = books.Find(b => b.ISBN == isbn);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            return true;
        }
        return false;
    }


    public bool IsBookAvailable(string title)
    {
        Book book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        return book != null && book.Available;
    }


    public void DisplayAllBooks()
    {
        Console.WriteLine("Library Inventory:");
        foreach (var book in books)
        {
            Console.WriteLine($"ISBN: {book.ISBN}, Title: {book.Title}, Author: {book.Author}, Available: {book.Available}");
        }
    }
}

class Program
{
    static void Main()
    {
 
        Book book1 = new Book
        {
            ISBN = "978-0-123456-78-9",
            Title = "C# Programming",
            Author = "John Smith",
            Available = true
        };

        Book book2 = new Book
        {
            ISBN = "978-0-234567-89-0",
            Title = "Object-Oriented Design",
            Author = "Jane Doe",
            Available = false
        };

  
        Library myLibrary = new Library();
        myLibrary.AddBook(book1);
        myLibrary.AddBook(book2);

 
        myLibrary.DisplayAllBooks();


        Console.WriteLine($"Is 'C# Programming' available? {myLibrary.IsBookAvailable("C# Programming")}");
    }
}
