using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.DAL.Reposetories
{
    public class BookRepository: IRepository<Book>
    {
        private readonly LibraryManagerContext _dbContext;

        public BookRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books;
        }

        public Book Get(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public void Create(Book item)
        {
            _dbContext.Add(item);
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
        }
    }
}
