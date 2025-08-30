using LibStory.Application.DTOs;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Maps
{
    public static class BookMapper
    {
        public static BookDTO ToDto(this Book book)
        {
            if (book == null) return null;
            return new BookDTO
            {
                Title = book.Title,
                Sinopsis = book.Sinopsis,
                Pages = book.Pages,
                Year = book.Year,
                Author = book.Author,
                Publisher = book.Publisher,
                Rating = book.Rating
            };
        }
        public static Book ToEntity(this BookDTO bookDto)
        {
            if (bookDto == null) return null;
            return new Book
            {
                Title = bookDto.Title,
                Sinopsis = bookDto.Sinopsis,
                Pages = bookDto.Pages,
                Year = bookDto.Year,
                Author = bookDto.Author,
                Publisher = bookDto.Publisher,
                Rating = bookDto.Rating
            };
        }
    }
}
