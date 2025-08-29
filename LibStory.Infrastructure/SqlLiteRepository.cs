using LibStory.Application.Interfaces;
using LibStory.Domain.Entities;
using LibStory.Domain.Models;
using LibStory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LibStory.Infrastructure
{
    public class SqlLiteRepository : IBookRepository
    {
        private readonly SqlLiteDbContext _context;
        public SqlLiteRepository(SqlLiteDbContext context)
        {
            _context = context;
        }
        
        public Task<bool> AddBookAsync(Book book)
        {
            _context.Books.Add((BookEntity)book);
                
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar en base de datos: " + ex.Message);
                return Task.FromResult(false);

            }
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteBook(long id)
        {
            try
            {
                var bookToRemove = await _context.Books.FindAsync(id);
                _context.Books.Remove(bookToRemove!);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar en base de datos: " + ex.Message);
                return false;
            }
            return true;
        }

        public Task<List<BookEntity>> GetAllBooks()
        {
            var books = new List<BookEntity>();
            books = _context.Books.ToList();
            return Task.FromResult(books);
        }

        public async Task<Book?> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return (Book)book;
        }

        public async Task<List<BookEntity>> GetBooksByTitle(string title)
        {
            var fileredBooks = await _context.Books
                .Where(e => e.Title != null)
                .Where(e => e.Title!.Contains(title))
                .ToListAsync();
            return fileredBooks;
        }

        public Task<bool> UpdateBook(Book book)
        {
            try
            {
                _context.Books.Update((BookEntity)book);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar en base de datos: " + ex.Message);
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
