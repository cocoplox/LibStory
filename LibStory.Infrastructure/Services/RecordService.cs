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
        public async Task<bool> AddRecordAsync(Record record)
        {
            var response = await _recordRepository.AddRecordAsync(record);
            return response;

        }
    }
}
