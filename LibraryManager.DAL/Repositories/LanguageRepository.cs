using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
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
            return _dbContext.Languages;
        }

        public Language Get(int id)
        {
            return _dbContext.Languages.Find(id);
        }

        public Language GetByName(string languageName)
        {
            return _dbContext.Languages.FirstOrDefault(x => x.LanguageName == languageName);
        }

        public void Create(Language item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }

        public void Update(Language item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var language = _dbContext.Languages.Find(id);
            if (language != null)
                _dbContext.Languages.Remove(language);
            _dbContext.SaveChangesAsync();
        }
    }
}
