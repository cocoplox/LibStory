using LibStory.Application.DTOs;
using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Queries
{
    public class BookByTitleQuery : IRequest<List<BookDTO>>
    {
        public string Title { get; set; }
        public class BookByTitleQueryHandler : IRequestHandler<BookByTitleQuery, List<BookDTO>>
        {
            private readonly IBookService _bookService;
            public BookByTitleQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }
            public async Task<List<BookDTO>> Handle(BookByTitleQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookService.GetBookByTitle(request.Title);
                return books.ToList();
            }

        }
    }
}
