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
    public class BookRepositoryTests
    {
        private LibraryManagerContext _dbContext;
        private IEnumerable<Book> testItems;

        public BookRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<LibraryManagerContext>()
                .UseInMemoryDatabase(databaseName: "Library").Options;
            _dbContext = new LibraryManagerContext(options);
            Seeder.SeedAll(_dbContext);
            testItems = Seeder.GetBookSeedItems(_dbContext);
        }

        [Fact]
        public void TestGetAllBooks()
        {
            //Arrange
            var sut = new BookRepository(_dbContext);

            //Act
            var actual = sut.GetAll();

            //Assert
            Assert.NotEmpty(actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestGetBookShouldNotBeNull(int bookId)
        {
            //Arrange
            var sut = new BookRepository(_dbContext);

            //Act
            var expected = sut.Get(bookId);

            //Assert
            Assert.NotNull(expected);
        }

        [Theory]
        [InlineData("White Fang")]
        [InlineData("Three Comrades")]
        [InlineData("The Mysterious Island")]
        public void TestGetByNameShouldNotBeNull(string name)
        {
            //Arrange
            var sut = new BookRepository(_dbContext);

            //Act
            var actual = sut.GetByName(name);

            //Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void TestBookShouldBeCreated()
        {
            //Arrange
            var sut = new BookRepository(_dbContext);
            Book test = new Book()
            {
                Author = new Author(),
               //AvailableLanguagesCollection = new List<Language>(),
               //GenresCollection = new List<Genre>(),
                NumberOfPages = 50,
                Rating = 10,
                Title = "Test"
            };

            //Act
            sut.Create(test);

            //Assert
            Assert.Contains(test, sut.GetAll());
        }

        //[Fact]
        //public void TestGetRandomShouldNotBeNull()
        //{
        //    //Arrange
        //    var sut = new BookRepository(_dbContext);

        //    //Act
        //    Book actual = sut.OpenRandom();

        //    //Assert
        //    Assert.NotNull(actual);
        //}

        [Theory]
        [InlineData(6)]
        public void TestBookShouldBeDeleted(int bookId)
        {
            //Arrange
            var sut = new BookRepository(_dbContext);

            //Act
            sut.Delete(bookId);


            //Assert
            Assert.Null(sut.Get(bookId));
        }
    }
}
