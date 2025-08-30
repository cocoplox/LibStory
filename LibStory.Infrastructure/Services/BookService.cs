using LibStory.Application.DTOs;
using LibStory.Application.Interfaces;
using LibStory.Application.Maps;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure.Services
{
    public class BookService : IBookService 
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> SaveBook(BookDTO book)
        {
            return await _bookRepository.AddBookAsync(book.ToEntity());
        }
        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return books.Select(e => e.ToDto()).ToList();
        }

        public async Task<List<BookDTO>> GetBookByTitle(string title)
        {
            var bookEntities = await _bookRepository.GetBooksByTitle(title) ?? new List<Book>();
            var bookDto = bookEntities.Select(e => e.ToDto());
            return bookDto.ToList();
        }
    }
}
