using LibStory.Domain.Entities;
using LibStory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibStory.Infrastructure.Context
{
    public class SqlLiteDbContext : DbContext
    {
        public DbSet<BookEntity> Books { get; set; }
        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
