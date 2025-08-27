using LibStory.Application.Interfaces;
using LibStory.Domain.Entities;
using LibStory.Infrastructure;
using LibStory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibStory.Tests.Repositories
{
    [TestFixture]
    public class SqlRepository
    {
        private SqlLiteDbContext _context;
        private IBookRepository _bookRepository;
        [OneTimeSetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<SqlLiteDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
            _context = new SqlLiteDbContext(options);

            //Añadimos Libros de prueba al contexto
            _context.Books.Add(new BookEntity
            {
                Title = "El Camino de los reyes",
                Sinopsis = "Muy bueno",
                Author = "Brandon Sanderson",
                Pages = 1007,
                Publisher = "Nova",
                Rating = 10f,
                Year = 2015
            });
            _context.Books.Add(new BookEntity
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
        [OneTimeTearDown]
        public void CleanUp()
        {
            _context.Dispose();
        }
    }
}
