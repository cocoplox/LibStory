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
        public RecordDTO RecordDTO { get; set; }
        public class AddRecordCommandHandler : IRequestHandler<AddRecordCommand, bool>
        {
            private readonly IRecordService _recordService;
            private readonly IManager _manager;
            public AddRecordCommandHandler(IRecordService recordService, IManager manager)
            {
                _recordService = recordService;
                _manager = manager;
            }
            public async Task<bool> Handle(AddRecordCommand request, CancellationToken cancellationToken)
            {
                return default;
            }
        }
    }
}
