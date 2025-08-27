using LibStory.Domain.Enums;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Interfaces
{
    public interface IManager
    {
        Book CreateBook();
        void PrintBook(Book book);
        void PrintBooks(List<Book> books);
    }
}
