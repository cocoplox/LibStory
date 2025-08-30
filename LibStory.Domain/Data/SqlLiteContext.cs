using System;
using System.Collections.Generic;
using LibStory.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibStory.Domain.Data;

public partial class SqlLiteContext : DbContext
{
    public SqlLiteContext()
    {
    }

    public SqlLiteContext(DbContextOptions<SqlLiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Book { get; set; }

    public virtual DbSet<Record> Record { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=C:\\Users\\ivanv\\AppData\\Roaming\\LibStory\\LibStory.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Record>(entity =>
        {
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp")
                .HasColumnType("datetime");
            entity.Property(e => e.PageDiff).HasComputedColumnSql();

            entity.HasOne(d => d.Book).WithMany(p => p.Record)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.Record)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_User_Email").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("DATETIME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
