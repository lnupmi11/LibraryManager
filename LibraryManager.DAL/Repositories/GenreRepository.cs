using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
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
            return _dbContext.Genres;
        }

        public Genre Get(int id)
        {
            return _dbContext.Genres.Find(id);
        }

        public Genre GetByName(string genreName)
        {
            return _dbContext.Genres.FirstOrDefault(x => x.GenreName == genreName);
        }

        public void Create(Genre item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Genre item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var genre = _dbContext.Genres.Find(id);
            if (genre != null)
                _dbContext.Genres.Remove(genre);
            _dbContext.SaveChangesAsync();
        }

    }
}
