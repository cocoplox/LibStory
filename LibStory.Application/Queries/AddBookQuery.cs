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
    public class AddBookQuery : IRequest<Book>
    {
        public class AddBookQueryHandler : IRequestHandler<AddBookQuery, Book>
        {
            private readonly IBookService _bookService;
            public AddBookQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }
            public Task<Book> Handle(AddBookQuery request, CancellationToken cancellationToken)
            {
                var book = _bookService.CreateBook();
                return Task.FromResult(book);
            }
        }
    }
}
