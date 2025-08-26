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
    public class AddBookQuery : IRequest<bool>
    {
        public class AddBookQueryHandler : IRequestHandler<AddBookQuery, bool>
        {
            private readonly IBookService _bookService;
            public AddBookQueryHandler(IBookService bookService)
            {
                _bookService = bookService;
            }
            public async Task<bool> Handle(AddBookQuery request, CancellationToken cancellationToken)
            {
                return await _bookService.CreateBook();
            }
        }
    }
}
