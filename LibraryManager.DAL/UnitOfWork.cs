using System;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Reposetories;
using LibraryManager.DAL.Interfaces;

namespace LibraryManager.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private LibraryManagerContext context;
        private bool disposed;

        private IRepository<Author, int> authorRepository;
        private IRepository<User, string> userRepository;
        private IRepository<Book, int> bookRepository;
        
        public UnitOfWork(LibraryManagerContext context)
        {
            this.context = context;
            this.disposed = false;
        }

        public IRepository<Author, int> AuthorRepository
        {
            get
            {
                return authorRepository;
            }
            set
            {
                this.authorRepository = value ?? new AuthorRepository(context);
            }
        }

        public IRepository<User, string> UserRepository
        {
            get
            {
                return userRepository;
            }
            set
            {
                this.userRepository = value ?? new UserRepository(context);
            }
        }

        public IRepository<Book, int> BookRepository
        {
            get
            {
                return bookRepository;
            }
            set
            {
                this.bookRepository = value ?? new BookRepository(context);
            }
        }

        public void Save()
        {
            if (context != null)
            {
                context.SaveChanges();
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
