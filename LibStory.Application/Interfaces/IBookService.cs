using LibStory.Application.DTOs;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Interfaces
{
    public interface IBookService
    {
        Task<bool> SaveBook(BookDTO book);
        Task<List<BookDTO>> GetAllBooks();
        Task<IEnumerable<BookDTO?>> GetBookByTitle(string title);

    }
}
