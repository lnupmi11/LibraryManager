using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.DAL.Repositories
{
    public class AuthorRepository : IRepository<Author, int>
    {
        private readonly LibraryManagerContext _dbContext;

        public AuthorRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Author> GetAll()
        {
            return _dbContext.Authors.ToList();
        }

        public Author Get(int id)
        {
            return GetAll().FirstOrDefault(a => a.Id == id);
        }

        public void Create(Author item)
        {
            _dbContext.Authors.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Author item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = Get(id);
            if (author != null)
                _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }         
    }
}
