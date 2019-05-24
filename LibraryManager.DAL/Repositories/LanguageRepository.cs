using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Context;
using Microsoft.EntityFrameworkCore;



namespace LibraryManager.DAL.Repositories
{
    public class LanguageRepository : IRepository<Language, int>
    {
        private readonly LibraryManagerContext _dbContext;

        public LanguageRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Language> GetAll()
        {
            return _dbContext.Languages.ToList();
        }

        public Language Get(int id)
        {
            return GetAll().FirstOrDefault(l => l.Id == id);
        }

        public Language GetByName(string languageName)
        {
            return GetAll().FirstOrDefault(l => l.LanguageName == languageName);
        }

        public void Create(Language item)
        {
            _dbContext.Add(item);
        }

        public void Update(Language item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var language = Get(id);
            if (language != null)
                _dbContext.Languages.Remove(language);
        }
    }
}
