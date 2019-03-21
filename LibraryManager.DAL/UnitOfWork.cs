using System;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Reposetories;

namespace LibraryManager.DAL
{
    public class UnitOfWork:IDisposable
    {
        private readonly LibraryManagerContext _dbContext = new LibraryManagerContext();
        private BookRepository _bookRepository;

        public BookRepository Books => _bookRepository ?? (_bookRepository = new BookRepository(_dbContext));

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
