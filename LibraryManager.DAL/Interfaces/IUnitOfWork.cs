using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Reposetories;
using LibraryManager.DAL.Interfaces;

namespace LibraryManager.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Author, int> AuthorRepository { get; set; }

        IRepository<User, string> UserRepository { get; set; }

        IRepository<Book, int> BookRepository { get; set; }

        IRepository<Language, int> LanguageRepository { get; set; }

        void Save();
    }
}
