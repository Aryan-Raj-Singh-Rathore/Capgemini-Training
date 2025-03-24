namespace LibraryManagement
{
    public class Book
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }
        public int PublicationYear { get; }
        public bool IsAvailable { get; set; }

        public Book(string isbn, string title, string author, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentException("ISBN cannot be empty.");
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title cannot be empty.");
            if (string.IsNullOrWhiteSpace(author)) throw new ArgumentException("Author cannot be empty.");
            if (publicationYear > DateTime.Now.Year) throw new ArgumentException("Publication year cannot be in the future.");

            ISBN = isbn;
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            IsAvailable = true;
        }
    }
}
