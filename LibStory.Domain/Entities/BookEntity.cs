using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Domain.Entities
{
    public class BookEntity
    {
        [Required]
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Sinopsis { get; set; }
        public int? Pages { get; set; }
        public int? Year { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public float? Rating { get; set; }
        public static explicit operator BookEntity(Book model) => new BookEntity
        {
            Title = model.Title,
            Sinopsis = model.Sinopsis,
            Pages = model.Pages,
            Year = model.Year,
            Author = model.Author,
            Publisher = model.Publisher,
            Rating = model.Rating
        };
    }
}
