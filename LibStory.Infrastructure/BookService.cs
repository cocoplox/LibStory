using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure
{
    public class BookService : IBookService 
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> CreateBook()
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
                Sinapsis = sinapsis,
                Author = author,
                Publisher = publisher,
                Pages = (int)pages,
                Rating = rating,
                Year = (int)year
            };
            bool correct = await _bookRepository.AddBookAsync(book);
            if (!correct)
            {
                Console.WriteLine("Error saving the book, please try again.");
                return correct;
            }
            Console.WriteLine("Book created successfully.");
            return correct;
          }

        public async Task<List<Book>> GetAllBooks()
        {
            List<Book> books = await _bookRepository.GetAllBooks();
            return books;
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
