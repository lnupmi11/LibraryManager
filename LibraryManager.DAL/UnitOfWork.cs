﻿using System;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
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
                if(this.authorRepository == null)
                {
                    this.authorRepository = new AuthorRepository(context);
                }
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
                if (this.UserRepository == null)
                {
                    this.UserRepository = new UserRepository(context);
                }
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
                if (this.BookRepository == null)
                {
                    this.BookRepository = new BookRepository(context);
                }
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
