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
        public async Task<bool> SaveBook(Book book)
        {
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
            var books = await _bookRepository.GetAllBooks();
            return books.Select(e => (Book)e).ToList();
        }
    }
}
