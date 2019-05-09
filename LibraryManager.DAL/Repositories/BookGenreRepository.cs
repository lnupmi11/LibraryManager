using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    class BookGenreRepository : IManyToManyRepository<BookGenre, int, int>
    {
        private readonly LibraryManagerContext _dbContext;
        private readonly BookRepository _bookRepository;
        private readonly GenreRepository _genreRepository;

        public BookGenreRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
            _bookRepository = new BookRepository(dbContext);
            _genreRepository = new GenreRepository(dbContext);
        }

        public void Create(BookGenre item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public void Delete(int tId, int vId)
        {
            throw new NotImplementedException();
        }

        public BookGenre Get(int tId, int vId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookGenre> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(BookGenre item)
        {
            throw new NotImplementedException();
        }
    }
}
