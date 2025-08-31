using LibStory.Application.DTOs;
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
    public class AddRecordCommand : IRequest<bool>
    {
        public string BookTitle { get; set; }
        public int PageFrom { get; set; }
        public int PageTo { get; set; }
        public class AddRecordCommandHandler : IRequestHandler<AddRecordCommand, bool>
        {
            private readonly IRecordService _recordService;
            private readonly IBookService _bookService;
            public AddRecordCommandHandler(IRecordService recordService, IBookService bookService)
            {
                _recordService = recordService;
                _bookService = bookService;
            }
            public async Task<bool> Handle(AddRecordCommand request, CancellationToken cancellationToken)
            {
                var books = await _bookService.GetBookByTitle(request.BookTitle);
                var book = books.FirstOrDefault();
                var record = new RecordDTO
                {
                    BookId = book?.Id ?? 0,
                    UserId = 1,
                    PageFrom = request.PageFrom,
                    PageTo = request.PageTo,
                };
                var response = await _recordService.AddRecordAsync(record);

                return response;
            }
        }
    }
}
