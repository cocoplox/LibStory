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
    public class PrintAllBooksQuery : IRequest<bool>
    {
        public class PrintAllBooksQueryHandler : IRequestHandler<PrintAllBooksQuery, bool>
        {
            private readonly IBookService _bookService;
            private readonly IManager _manager;
            public PrintAllBooksQueryHandler(IBookService service, IManager manager)
            {
                _bookService = service;
                _manager = manager;
            }
            public async Task<bool> Handle(PrintAllBooksQuery request, CancellationToken cancellationToken)
            {
                List<Book> books = await _bookService.GetAllBooks();
                _manager.PrintBooks(books);
                return true;

            }
        }
    }
}
