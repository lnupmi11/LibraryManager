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

        private AuthorRepository authorRepository;
        private UserRepository userRepository;
        private BookRepository bookRepository;
        
        public UnitOfWork(LibraryManagerContext context)
        {
            this.context = context;
            this.disposed = false;
        }

        public AuthorRepository AuthorRepository
        {
            get
            {
                if (this.authorRepository == null)
                {
                    this.authorRepository = new AuthorRepository(context);
                }
                return authorRepository;
            }
        }

        public UserRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
                }
                return userRepository;
            }
        }

        public BookRepository BookRepository
        {
            get
            {
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(context);
                }
                return bookRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
