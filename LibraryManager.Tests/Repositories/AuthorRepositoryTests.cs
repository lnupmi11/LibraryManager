using LibraryManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using LibraryManager.DAL.Repositories;
using LibraryManager.DAL.Seeding;
using LibraryManager.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Xunit;
using Moq;
using System.Threading;

namespace LibraryManager.Tests
{
    public class AuthorRepositoryTests
    {
        private LibraryManagerContext _dbContext;
        private IEnumerable<Author> testItems;

        public AuthorRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<LibraryManagerContext>()
                .UseInMemoryDatabase(databaseName: "LibraryAuthorTests").Options;
            _dbContext = new LibraryManagerContext(options);
            Seeder.SeedAll(_dbContext);
            testItems = Seeder.GetAuthorSeedItems();
        }

        [Fact]
        public void TestGetAllAuthors()
        {
            //Arrange
            var authorRepository = new AuthorRepository(_dbContext);

            //Act
            var actual = authorRepository.GetAll();

            //Assert
            Assert.NotEmpty(actual);
        }

        [Theory]
        [InlineData("Verne")]
        [InlineData("London")]
        public void TestGetAuthorShouldNotBeNull(string authorLastName)
        {
            //Arrange
            var authorRepository = new AuthorRepository(_dbContext);

            //Act
            var expected = authorRepository.GetAll().FirstOrDefault(x => x.LastName == authorLastName);

            //Assert
            Assert.NotNull(expected);
        }
       
        [Fact]
        public void TestAuthorShouldBeCreated()
        {
            //Arrange
            var authorRepository = new AuthorRepository(_dbContext);
            var author = new Author()
            {
                FirstName = "Steven",
                LastName  = "King",
                NumberOfWrittenBooks = 99
            };

            //Act
            authorRepository.Create(author);
            _dbContext.SaveChanges();

            //Assert
            Assert.Contains(author, authorRepository.GetAll());
        }

       
        [Theory]
        [InlineData(3)]
        public void TestAuthorShouldBeDeleted(int AuthorId)
        {
            //Arrange
            var authorRepository = new AuthorRepository(_dbContext);

            //Act
            authorRepository.Delete(AuthorId);
            _dbContext.SaveChanges();

            //Assert
            Assert.Null(authorRepository.Get(AuthorId));
        }
    }
}
