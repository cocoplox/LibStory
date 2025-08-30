using LibStory.Application.Interfaces;
using LibStory.Domain.Data;
using LibStory.Domain.Models;
using LibStory.Infrastructure;
using LibStory.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibStory.Tests.Repositories
{
    [TestFixture]
    public class SqlRepository
    {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private SqlLiteContext _context;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        private IBookRepository _bookRepository;
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SqlLiteContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new SqlLiteContext(options);

            //Añadimos Libros de prueba al contexto
            _context.Book.Add(new Book 
            {
                Title = "El Camino de los reyes",
                Sinopsis = "Muy bueno",
                Author = "Brandon Sanderson",
                Pages = 1007,
                Publisher = "Nova",
                Rating = 10f,
                Year = 2015
            });
            _context.Book.Add(new Book
            {
                Title = "El Nombre del Viento",
                Sinopsis = "Muy bueno",
                Author = "Patrik Rothfuss",
                Pages = 880,
                Publisher = "Dissello",
                Rating = 9.8f,
                Year = 2000
            });
            _context.SaveChanges();
            _bookRepository = new SqlLiteRepository(_context);
        }
        [TestCase("El Camino de los reyes")]
        public async Task Should_Filter_By_Title(string title)
        {
            //Act
            var filteredBooks = await _bookRepository.GetBooksByTitle(title);
            //Assert
            Assert.That(1 == filteredBooks.Count);
            Assert.That(filteredBooks.All(e => e.Title != null));
            Assert.That(filteredBooks.All(e => e.Title!.Contains(title)));
        }
        [Test]
        public async Task Should_Delete_By_Id()
        {
            //Arrange
            var booksBefore = await _bookRepository.GetAllBooks();
            var bookToDelete = booksBefore.First();
            //Act
            var result = await _bookRepository.DeleteBook((int)bookToDelete.Id);
            var booksAfter = await _bookRepository.GetAllBooks();
            //Assert
            Assert.That(result);
            Assert.That(booksAfter.Count == booksBefore.Count - 1);
            Assert.That(booksAfter.All(e => e.Id != bookToDelete.Id));
        }
        [OneTimeTearDown]
        public void CleanUp()
        {
            _context.Dispose();
        }
    }
}
