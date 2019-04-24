using LibraryManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using LibraryManager.DAL.Repositories;
using LibraryManager.DAL.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;
using Moq;

namespace LibraryManager.Tests
{
    public class LanguageRepositoryTests
    {
        private LibraryManagerContext _dbContext;
        private IEnumerable<Language> testItems;

        public LanguageRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<LibraryManagerContext>()
                .UseInMemoryDatabase(databaseName: "Library").Options;
            _dbContext = new LibraryManagerContext(options);
            Seeder.SeedAll(_dbContext);
            testItems = Seeder.GetLanguageSeedItems();
        }

        [Fact]
        public void TestGetAllLanguage()
        {
            //Arrange
            var languageRepository = new LanguageRepository(_dbContext);

            //Act
            var actual = languageRepository.GetAll();

            //Assert
            Assert.NotEmpty(actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestGetLanguageShouldNotBeNull(int LanguageId)
        {
            //Arrange
            var languageRepository = new LanguageRepository(_dbContext);

            //Act
            var expected = languageRepository.Get(LanguageId);

            //Assert
            Assert.NotNull(expected);
        }

        [Fact]
        public void TestLanguageShouldBeCreated()
        {
            //Arrange
            var languageRepository = new LanguageRepository(_dbContext);
            var language = new Language()
            {
                LanguageName = "Ukraine"
            };

            //Act
            languageRepository.Create(language);

            //Assert
            Assert.Contains(language, languageRepository.GetAll());
        }


        [Theory]
        [InlineData(3)]
        public void TestLanguageShouldBeDeleted(int LanguageId)
        {
            //Arrange
            var authorRepository = new AuthorRepository(_dbContext);

            //Act
            authorRepository.Delete(LanguageId);

            //Assert
            Assert.Null(authorRepository.Get(LanguageId));
        }
    }
}
