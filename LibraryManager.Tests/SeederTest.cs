using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Context;
using LibraryManager.DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace LibraryManager.Tests
{
    public class SeederTest
    {
        private LibraryManagerContext _dbContext;

        public SeederTest()
        {
            var options = new DbContextOptionsBuilder<LibraryManagerContext>()
                .UseInMemoryDatabase(databaseName: "Library").Options;
            _dbContext = new LibraryManagerContext(options);
        }

        [Fact]
        public void TestSeedAll()
        {
            Seeder.SeedAll(_dbContext);
            _dbContext.SaveChanges();

            Assert.True(_dbContext.Books.ToList().All(shouldItem => Seeder.GetBookSeedItems(_dbContext).Any(isItem => isItem.Title == shouldItem.Title)));
            Assert.True(_dbContext.Genres.ToList().All(shouldItem => Seeder.GetGenreSeedItems().Any(isItem => isItem.GenreName == shouldItem.GenreName)));
            Assert.True(_dbContext.Authors.ToList().All(shouldItem => Seeder.GetAuthorSeedItems().Any(isItem => isItem.LastName == shouldItem.LastName)));
            Assert.True(_dbContext.Languages.ToList().All(shouldItem => Seeder.GetLanguageSeedItems().Any(isItem => isItem.LanguageName == shouldItem.LanguageName)));
        }
        
    }
}
