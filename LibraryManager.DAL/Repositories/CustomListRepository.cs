using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    public class CustomListRepository: IRepository<CustomList, int>
    {
        private readonly LibraryManagerContext _dbContext;

        public CustomListRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(CustomList item)
        {
            _dbContext.CustomList.Add(item);

        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
                _dbContext.CustomList.Remove(item);
        }

        public CustomList Get(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);

        }

        public IEnumerable<CustomList> GetAll()
        {
            return _dbContext.CustomList.ToList();
        }

        public void Update(CustomList item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}



 
 
 