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
            private readonly IManager _manager;
            public AddBookQueryHandler(IBookService bookService, IManager manager)
            {
                _bookService = bookService;
                _manager = manager;
            }
            public async Task<bool> Handle(AddBookQuery request, CancellationToken cancellationToken)
            {
                var bookToSave = _manager.CreateBook();
                return await _bookService.SaveBook(bookToSave);
            }
        }
    }
}
