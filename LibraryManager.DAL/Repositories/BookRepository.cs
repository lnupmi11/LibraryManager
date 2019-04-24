using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.DAL.Repositories
{
    public class BookRepository: IRepository<Book, int>
    {
        private readonly LibraryManagerContext _dbContext;

        public BookRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books
                .Include(b => b.Genres)
                .Include(b => b.Languages).ToList();
        }

        public Book Get(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public Book GetByName(string bookName)
        {
           return _dbContext.Books.FirstOrDefault(x => x.Title == bookName);
        }

        public void Create(Book item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Book item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book != null)
                _dbContext.Books.Remove(book);
            _dbContext.SaveChangesAsync();
        }
        public Book OpenRandom()
        {
            var numberOfBooks = _dbContext.Books.Count();
            var random = new Random();
            var randomBook = _dbContext.Books.FirstOrDefault(x => x.Id == random.Next(1, numberOfBooks));

            return randomBook;
        }
    }
}
