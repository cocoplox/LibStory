using LibStory.Application.DTOs;
using LibStory.Application.Interfaces;
using LibStory.Application.Maps;
using LibStory.Domain.Data;
using LibStory.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibStory.Infrastructure.Repositories
{
    public class SqlLiteRepository : IBookRepository
    {
        private readonly SqlLiteContext _context;
        public SqlLiteRepository(SqlLiteContext context)
        {
            _context = context;
        }
        
        public Task<bool> AddBookAsync(Book book)
        {
            _context.Book.Add(book);
                
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
                var bookToRemove = await _context.Book.FindAsync(id);
                _context.Book.Remove(bookToRemove!);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar en base de datos: " + ex.Message);
                return false;
            }
            return true;
        }

        public Task<List<Book>> GetAllBooks()
        {
            var books = new List<Book>();
            books = _context.Book.ToList();
            return Task.FromResult(books);
        }

        public async Task<Book?> GetBookById(int id)
        {
            var book = await _context.Book.FindAsync(id);
            return book;
        }

        public async Task<List<Book>> GetBooksByTitle(string title)
        {
            var fileredBooks = await _context.Book
                .Where(e => e.Title != null)
                .Where(e => e.Title!.ToLower().Contains(title.ToLower()))
                .ToListAsync();
            return fileredBooks;
        }

        public Task<bool> UpdateBook(Book book)
        {
            try
            {
                _context.Book.Update(book);
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
