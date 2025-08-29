using LibStory.Domain.Entities;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(Book book);
        Task<List<BookEntity>> GetAllBooks();
        Task<List<BookEntity>> GetBooksByTitle(string title);
        Task<Book?> GetBookById(int id);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(long id);
    }
}
