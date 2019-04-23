using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Interfaces
{
    public interface IRepository<T, TId> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(TId id);

        void Create(T item);

        void Update(T item);

        void Delete(TId id);
    }
}
