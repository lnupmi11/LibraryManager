using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    class GenreRepository:IRepository<Genre,int>
    {
        private readonly LibraryManagerContext _dbContext;

        public GenreRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Genre> GetAll()
        {
            return _dbContext.Genres.ToList();
        }

        public Genre Get(int id)
        {
            return GetAll().FirstOrDefault(g => g.Id == id);
        }

        public Genre GetByName(string genreName)
        {
            return GetAll().FirstOrDefault(g => g.GenreName == genreName);
        }

        public void Create(Genre item)
        {
            _dbContext.Add(item);
        }

        public void Update(Genre item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var genre = Get(id);
            if (genre != null)
                _dbContext.Genres.Remove(genre);
        }

    }
}
