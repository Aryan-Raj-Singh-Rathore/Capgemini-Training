using NUnit.Framework;
using System;

namespace LibraryManagement.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void Constructor_ShouldInitializePropertiesCorrectly()
        {
            // Arrange & Act
            var book = new Book("12345", "Test Book", "Aryan Raj Singh Rathore", 2020);

            // Assert
            Assert.That(book.ISBN, Is.EqualTo("12345"));
            Assert.That(book.Title, Is.EqualTo("Test Book"));
            Assert.That(book.Author, Is.EqualTo("Aryan Raj Singh Rathore"));
            Assert.That(book.PublicationYear, Is.EqualTo(2020));
            Assert.That(book.IsAvailable, Is.True);
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenISBNIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("", "Valid Title", "Author", 2020));
            Assert.Throws<ArgumentException>(() => new Book(null, "Valid Title", "Author", 2020));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenTitleIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("12345", "", "Author", 2020));
            Assert.Throws<ArgumentException>(static() => new Book("12345", null, "Author", 2020));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenAuthorIsNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Book("12345", "Valid Title", "", 2020));
            Assert.Throws<ArgumentException>(static() => new Book("12345", "Valid Title", null, 2020));
        }

        [Test]
        public void Constructor_ShouldThrowException_WhenPublicationYearIsInFuture()
        {
            int futureYear = DateTime.Now.Year + 1;
            Assert.Throws<ArgumentException>(() => new Book("12345", "Valid Title", "Author", futureYear));
        }

        [Test]
        public void IsAvailable_ShouldChangeState_WhenUpdated()
        {
            // Arrange
            var book = new Book("12345", "Test Book", "Aryan Raj Singh Rathore", 2020);

            // Act
            book.IsAvailable = false;

            // Assert
            Assert.IsFalse(book.IsAvailable);

            // Act
            book.IsAvailable = true;

            // Assert
            Assert.IsTrue(book.IsAvailable);
        }
    }
}
