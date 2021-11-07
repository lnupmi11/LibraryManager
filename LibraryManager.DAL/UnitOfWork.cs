using System;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;

namespace LibraryManager.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private LibraryManagerContext context;
        private bool disposed;

        private IRepository<Author, int> authorRepository;
        private IRepository<User, string> userRepository;
        private IRepository<Book, int> bookRepository;
        private IRepository<Language, int> languageRepository;
        private IRepository<Genre, int> genreRepository;
        private IRepository<CustomList, int> customListRepository;

        private IManyToManyRepository<Entities.ListBook, int, int> listBookRepository;
        private IManyToManyRepository<UserBook, string,int> userBookRepository;
        private IManyToManyRepository<BookGenre, int, int> bookGenreRepository { get; set; }


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
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(context);
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
                if (this.bookRepository == null)
                {
                    this.bookRepository = new BookRepository(context);
                }
                return bookRepository;
            }
            set
            {
                this.bookRepository = value ?? new BookRepository(context);
            }
        }

        public IRepository<Language, int> LanguageRepository
        {
            get
            {
                if (this.languageRepository == null)
                {
                    this.languageRepository = new LanguageRepository(context);
                }

                return languageRepository;
            }
            set
            {
                this.languageRepository = value ?? new LanguageRepository(context);
            }
        }

        public IRepository<Genre, int> GenreRepository
        {
            get
            {
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenreRepository(context);
                }

                return genreRepository;
                
            }
            set
            {
                this.genreRepository = value ?? new GenreRepository(context);
            }
        }


        public IRepository<CustomList, int> CustomListRepository
        {
            get
            {
                if (this.customListRepository == null)
                {
                    this.customListRepository = new CustomListRepository(context);
                }

                return customListRepository;

            }
            set
            {
                this.customListRepository = value ?? new CustomListRepository(context);
            }
        }

        public IManyToManyRepository<UserBook, string, int> UserBookRepository
        {
            get
            {
                if (this.userBookRepository == null)
                {
                    this.userBookRepository = new UserBookRepository(context);
                }

                return userBookRepository;

            }
            set
            {
                this.userBookRepository = value ?? new UserBookRepository(context);
            }
        }

        public IManyToManyRepository<BookGenre, int, int> BookGenreRepository
        {
            get
            {
                if (this.bookGenreRepository == null)
                {
                    this.bookGenreRepository = new BookGenreRepository(context);
                }

                return bookGenreRepository;

            }
            set
            {
                this.bookGenreRepository = value ?? new BookGenreRepository(context);
            }
        }

        public IManyToManyRepository<ListBook, int, int> ListBookRepository
        {
            get
            {
                if (this.listBookRepository == null)
                {
                    this.listBookRepository = new ListBookRepository(context);
                }

                return listBookRepository;

            }
            set
            {
                this.listBookRepository = value ?? new ListBookRepository(context);
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
