using LibStory.Application.Interfaces;
using LibStory.Domain.Entities;
using LibStory.Domain.Models;
using LibStory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _context.Add<BookEntity>((BookEntity)book);
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

        public Task<bool> DeleteBook(int id)
        {
            //TODO
            throw new NotImplementedException();
        }

        public Task<List<BookEntity>> GetAllBooks()
        {
            var books = new List<BookEntity>();
            books = _context.Books.ToList();
            return Task.FromResult(books);
        }

        public Task<Book?> GetBookById(int id)
        {
            //TODO
            throw new NotImplementedException();
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
            //TODO
            throw new NotImplementedException();
        }
    }
}
