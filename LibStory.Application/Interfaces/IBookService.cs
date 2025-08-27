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
        Task<bool> SaveBook(Book book);
        Task<List<Book>> GetAllBooks();
        //bool SaveBook(Book book);

    }
}
