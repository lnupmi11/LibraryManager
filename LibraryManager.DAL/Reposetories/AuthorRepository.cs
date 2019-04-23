using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.DAL.Reposetories
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
            return _dbContext.Authors;
        }

        public Author Get(int id)
        {
            return _dbContext.Authors.Find(id);
        }

        public void Create(Author item)
        {
            _dbContext.Authors.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Author item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author != null)
                _dbContext.Authors.Remove(author);
            _dbContext.SaveChanges();
        }         
    }
}
