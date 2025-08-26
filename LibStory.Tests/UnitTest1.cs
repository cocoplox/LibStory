using LibStory.Application.Interfaces;
using LibStory.Application.Queries;
using Moq;

namespace LibStory.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task ShouldCreateBook()
        {
            // Arrange
            var expectedBook = new Domain.Models.Book()
            {
                Title = "Test Book",
                Sinopsis = "This is a test book",
                Pages = 100,
                Year = 2023,
                Author = "Test Author",
                Publisher = "Test Publisher"
            };

            var mockedService = new Mock<IBookService>();
            mockedService.Setup(e => e.CreateBook()).Returns(expectedBook);

            var handler = new AddBookQuery.AddBookQueryHandler(mockedService.Object);
            var query = new AddBookQuery(); // Asumiendo que AddBookQuery no requiere parámetros

            // Act
            var resultBook = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(resultBook);
            Assert.AreEqual(expectedBook.Title, resultBook.Title);
            Assert.AreEqual(expectedBook.Sinopsis, resultBook.Sinapsis);
            Assert.AreEqual(expectedBook.Pages, resultBook.Pages);
            Assert.AreEqual(expectedBook.Year, resultBook.Year);
            Assert.AreEqual(expectedBook.Author, resultBook.Author);
            Assert.AreEqual(expectedBook.Publisher, resultBook.Publisher);
        }
    }
}