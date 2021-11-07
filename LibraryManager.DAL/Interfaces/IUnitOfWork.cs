﻿using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Repositories;
using LibraryManager.DAL.Interfaces;

namespace LibraryManager.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author, int> AuthorRepository { get; set; }

        IRepository<User, string> UserRepository { get; set; }

        IRepository<Book, int> BookRepository { get; set; }

        IRepository<Language, int> LanguageRepository { get; set; }

        IRepository<Genre, int> GenreRepository { get; set; }

        IRepository<CustomList, int> CustomListRepository { get; set; }

        IManyToManyRepository<ListBook, int, int> ListBookRepository {get;set;}

        IManyToManyRepository<UserBook,string, int> UserBookRepository { get; set; }

        IManyToManyRepository<BookGenre, int, int> BookGenreRepository { get; set; }


        void Save();
    }
}
