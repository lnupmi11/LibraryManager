using System;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Reposetories;

namespace LibraryManager.DAL
{
    public class UnitOfWork
    {
        private LibraryManagerContext context;
        private AuthorRepository authorRepository;
        private UserRepository userRepository;
        private BookRepository bookRepository;

        public UnitOfWork(LibraryManagerContext context)
        {
            this.context = context;
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
    }
}
