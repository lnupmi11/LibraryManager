using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Reposetories;

namespace LibraryManager.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        AuthorRepository AuthorRepository { get; }
    }
}
