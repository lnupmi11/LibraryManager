using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Interfaces
{
    public interface IManyToManyRepository<T, TId, VId> where T: class                                       
    {
        IQueryable<T> GetAll();

        T Get(TId tId,VId vId);

        void Create(T item);

        void Update(T item);

        void Delete(TId tId, VId vId);
    }
}
