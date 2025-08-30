using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Commands
{
    public class AddBookCommand : IRequest<bool>
    {
        public class AddBookCommandHandler : IRequestHandler<AddBookCommand, bool>
        {
            private readonly IBookService _bookService;
            private readonly IManager _manager;
            public AddBookCommandHandler(IBookService bookService, IManager manager)
            {
                _bookService = bookService;
                _manager = manager;
            }
            public async Task<bool> Handle(AddBookCommand request, CancellationToken cancellationToken)
            {
                var bookToSave = _manager.CreateBook();
                return await _bookService.SaveBook(bookToSave);
            }
        }
    }
}
