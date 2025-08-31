using LibStory.Application.DTOs;
using LibStory.Application.Interfaces;
using LibStory.Domain.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure.Services
{
    public class RecordService : IRecordService
    {
        private readonly IRecordRepository _recordRepository;
        public RecordService(IRecordRepository recordRepository)
        {
            _recordRepository = recordRepository;
        }
        public async Task<bool> AddRecordAsync(RecordDTO recordDto)
        {
            var mappedRecord = new Record
            {
                BookId = recordDto.BookId,
                UserId = recordDto.UserId,
                PageFrom = recordDto.PageFrom,
                PageTo = recordDto.PageTo,
            };
            var response = await _recordRepository.AddRecordAsync(mappedRecord);
            return response;
        }
        public async Task<IEnumerable<RecordDTO>> GetAllRecordsAsync()
        {
             var entities = await _recordRepository.GetAllRecordsAsync();
        }
    }
}
