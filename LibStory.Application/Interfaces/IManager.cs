using LibStory.Application.DTOs;
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
        BookDTO CreateBook();
        void PrintBook(BookDTO book);
        void PrintBooks(List<BookDTO> books);
        RecordDTO CreateRecord();
        void PrinteMessage(string message);
        string GetResponse(string message);
        
    }
}
