using AutoMapper;
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
        private readonly IMapper _mapper;
        public RecordService(IRecordRepository recordRepository, IMapper mapper)
        {
            _recordRepository = recordRepository;
            _mapper = mapper;
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
        public async Task<List<RecordDTO>> GetAllRecordsAsync()
        {
            var QRecords = await _recordRepository.GetAllRecordsAsync();
            var records = _mapper.Map<List<RecordDTO>>(QRecords.ToList());
            return records;
            
        }
    }
}
