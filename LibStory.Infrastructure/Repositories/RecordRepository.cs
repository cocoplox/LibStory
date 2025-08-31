using LibStory.Domain.Data;
using LibStory.Domain.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly SqlLiteContext _context;
        public RecordRepository(SqlLiteContext context)
        {
            _context = context;
        }
        public Task<bool> AddRecordAsync(Record record)
        {
            try
            {
                _context.Record.Add(record);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error al añadir el registro: " + ex.Message);
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
