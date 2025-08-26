using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure
{
    public class ConsoleManager : IManager
    {
        public void PrintBook(Book book)
        {
            Console.WriteLine("Book Details:");
            Console.WriteLine($"Book Title:{book.Title}");
            Console.WriteLine($"Book Sinapsis:{book.Sinopsis}");
            Console.WriteLine(book.Pages != 0 ? $"Book Pages:{book.Pages}" : "Book Pages: N/A");
            Console.WriteLine(book.Year != 0 ? $"Book Year:{book.Year}" : "Book Year: N/A");
            Console.WriteLine(book.Author != null ? $"Book Author:{book.Author}" : "Book Author: N/A");
            Console.WriteLine(book.Publisher != null ? $"Book Publisher:{book.Publisher}" : "Book Publisher: N/A");
        }

        public void PrintBooks(List<Book> books)
        {
            books.ForEach(e =>
            {
                PrintBook(e);
                Console.WriteLine(new string('-', 20));
            });
        }
    }
}
