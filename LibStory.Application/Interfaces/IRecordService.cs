using LibStory.Application.DTOs;

namespace LibStory.Application.Interfaces
{
    public interface IRecordService
    {
        Task<bool> AddRecordAsync(RecordDTO recordDto);
        Task<List<RecordDTO>> GetAllRecordsAsync();
    }
}
