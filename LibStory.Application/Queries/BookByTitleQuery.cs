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
    public class BookByTitleQuery : IRequest<Unit>
    {
        public string Title { get; set; }
        public class BookByTitleQueryHandler : IRequestHandler<BookByTitleQuery, Unit>
        {
            private readonly IBookService _bookService;
            private readonly IManager _manager;
            public BookByTitleQueryHandler(IBookService bookService, IManager manager)
            {
                _bookService = bookService;
                _manager = manager;
            }
            public async Task<Unit> Handle(BookByTitleQuery request, CancellationToken cancellationToken)
            {
                var books = await _bookService.GetBookByTitle(request.Title);
                if (books == null || !books.Any())
                {
                    Console.WriteLine("no books found with that title.");
                }
                else
                {
                    _manager.PrintBooks(books.ToList()!);
                }
                return Unit.Value;
            }

        }
    }
}
