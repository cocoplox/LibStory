using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.DTOs
{
    public class RecordDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int PageFrom { get; set; }
        public int PageTo { get; set; }
    }
}
