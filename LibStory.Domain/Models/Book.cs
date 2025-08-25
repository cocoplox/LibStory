using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Domain.Models
{
    public class Book
    {
        [Required]
        public string Title { get; set; }
        public string Sinapsis { get; set; }
        public int Pages { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public float Rating { get; set; }
    }
}
