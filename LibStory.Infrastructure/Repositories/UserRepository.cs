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
    public class UserRepository : IUserRepository
    {
        private readonly SqlLiteContext _context;
        public UserRepository(SqlLiteContext context)
        {
            _context = context;
        }
        public User? GetUser(int id)
        {
            return _context.User.Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
