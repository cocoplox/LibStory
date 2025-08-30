using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Sinopsis { get; set; }
        public int? Pages { get; set; }
        public int? Year { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public double? Rating { get; set; }
        public static explicit operator Book(BookDTO bookDto)
        {
            if (bookDto == null) return null;
            return new LibStory.Domain.Models.Book
            {
                Id = bookDto.Id,
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
