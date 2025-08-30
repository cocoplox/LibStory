using LibStory.Application.DTOs;
using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Application.Queries
{
    public class PrintBookQuery : IRequest<bool>
    {
        public BookDTO bookToPrint { get; set; }
        public class PrintBookQueryResponse : IRequestHandler<PrintBookQuery, bool>
        {
            private readonly IManager _manager;
            public PrintBookQueryResponse(IManager manager)
            {
                _manager = manager;
            }
            public Task<bool> Handle(PrintBookQuery request, CancellationToken cancellationToken)
            {
                if(request?.bookToPrint is null) { return Task.FromResult(false); }
                _manager.PrintBook(request.bookToPrint);
                return Task.FromResult(true);
            }

        }
    }
}
