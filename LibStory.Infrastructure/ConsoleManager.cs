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
        public Book CreateBook()
        {
            string title = GetBasicInfo("Title");
            string sinapsis = GetBasicInfo("Sinapsis");
            string author = GetBasicInfo("Author");
            string publisher = GetBasicInfo("Publisher");
            float pages = GetBasicNumberInfo("Pages");
            float rating = GetBasicNumberInfo("Rating");
            float year = GetBasicNumberInfo("Year");

            Book book = new Book
            {
                Title = title,
                Sinopsis = sinapsis,
                Author = author,
                Publisher = publisher,
                Pages = (int)pages,
                Rating = rating,
                Year = (int)year
            };
            return book;
        }

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
        private string GetBasicInfo(string infoName)
        {
            Console.Write($"Enter the {infoName}: ");
            return Console.ReadLine() ?? string.Empty;
        }
        private float GetBasicNumberInfo(string numerInfo)
        {
            Console.Write($"Enter the {numerInfo}: ");
            numerInfo = Console.ReadLine() ?? string.Empty;
            if (float.TryParse(numerInfo, out float number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid number, please try again.");
                return GetBasicNumberInfo(numerInfo);
            }
        }
    }
}
