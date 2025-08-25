using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure
{
    public class BookService : IBookService 
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
                Sinapsis = sinapsis,
                Author = author,
                Publisher = publisher,
                Pages = (int)pages,
                Rating = rating,
                Year = (int)year
            };
            return book;

        }

        public bool SaveBook(Book book)
        {
            Console.WriteLine("BookSaved");
            return true;
        }

        private string GetBasicInfo(string infoName)
        {
            Console.Write($"Enter the {infoName}: ");
            return Console.ReadLine();
        }
        private float GetBasicNumberInfo(string numerInfo)
        {
            Console.Write($"Enter the {numerInfo}: ");
            numerInfo = Console.ReadLine();
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
