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
    public class GetAllBooksQuery : IRequest<List<BookDTO>>
    {
        public class PrintAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<BookDTO>>
        {
            private readonly IBookService _bookService;
            public PrintAllBooksQueryHandler(IBookService service)
            {
                _bookService = service;
            }
            public async Task<List<BookDTO>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var response = await _bookService.GetAllBooks();
                return response;

            }
        }
    }
}
