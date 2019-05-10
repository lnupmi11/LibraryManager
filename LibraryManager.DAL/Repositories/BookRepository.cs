using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;
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
                .Include(b => b.Genres).ThenInclude(g => g.Genre)
                .Include(b => b.Languages).ThenInclude(l => l.Language)
                .Include(b => b.Author)
                .ToList();
        }

        public Book Get(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }

        public Book GetByName(string bookName)
        {
           return GetAll().FirstOrDefault(b => b.Title == bookName);
        }

        public void Create(Book item)
        {
            _dbContext.Add(item);
            //_dbContext.Set<BookGenre>().AddAsync(new BookGenre() {BookId=item.Id,GenreId=item. });
            //_dbContext.SaveChangesAsync();
        }

        public void Update(Book item)
        {
            item.Author = _dbContext.Authors.First(a => a.FirstName == item.Author.FirstName && a.LastName == item.Author.LastName) ??
                          new Author() {FirstName = item.Author.FirstName, LastName = item.Author.LastName};
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Get(id);
            if (book != null)
                _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
