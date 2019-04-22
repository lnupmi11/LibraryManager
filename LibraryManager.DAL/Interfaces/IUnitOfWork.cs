using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;

namespace LibraryManager.DAL.Interfaces
{
    interface IUnitOfWork: IDisposable
    {
        IRepository<Author> AuthorRepository { get; }
    }
}
