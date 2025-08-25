using LibStory.Application.Interfaces;
using LibStory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace LibStory.Infrastructure
{
    public class FileRepository : IBookRepository
    {
        private const string _fileName = "Library.json";
        private const string _directoryName = "LibStoryData";
        private  List<Book> _books;
        private string _filePath
        {
            get
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                var directory = Path.Combine(appData, _directoryName);

                if(!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                string path = Path.Combine(directory, _fileName);
                if(!File.Exists(path))
                {
                    File.WriteAllText(path, "[]");
                }
                return path;

            }
        }
        public FileRepository()
        {
            _books = LoadBooksFromFile();
        }

        public Task<bool> AddBookAsync(Book book)
        {
            _books.Add(book);
            string json = JsonSerializer.Serialize(_books, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Book>> GetAllBooks()
        {
            return Task.FromResult(LoadBooksFromFile());
        }

        public Task<Book?> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
        private List<Book> LoadBooksFromFile()
        {
            string json = File.ReadAllText(_filePath);
            return  JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }
        
    }
}
