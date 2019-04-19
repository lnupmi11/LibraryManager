using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LibraryManager.BLL.Interfaces;
using LibraryManager.BLL.Services;
using Moq;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using AutoMapper;
using LibraryManager.DTO.Models;
using System.Linq;

namespace LibraryManager.Tests
{
    public class LibraryManagerBllTests
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private Mock<IRepository<Book>> bookRepositoryMock;
        private Mock<IRepository<User>> userRepositoryMock;
        private Mock<IMapper> mapper;

        public LibraryManagerBllTests()
        {
            mapper = new Mock<IMapper>();
            userService = new UserService(userRepositoryMock.Object, mapper.Object);
            bookService = new BookService(bookRepositoryMock.Object, userService, mapper.Object);

            InitializeMock();
        }

        [Fact]
        public void BookGetAllTest()
        {
            var testCollection = GetBookCollection();

            var actualBookCollection = bookService.GetAll();

            Assert.Equal(testCollection.Count(), actualBookCollection.Count());
        }

        [Fact]
        public void UserGetAllTest()
        {
            var testCollection = GetUserCollection();

            var actualBookCollection = userService.GetAllUsers();

            Assert.Equal(testCollection.Count(), actualBookCollection.Count());
        }

        [Fact]
        public void BookGetById()
        {
            var testBook = GetBookCollection().ToList()[0];

            var actualBook = bookService.Find(0);

            Assert.Equal(testBook.Id, actualBook.Id);
        }

        [Fact]
        public void CreateBook()
        {
            bookService.Create(new BookDTO { Id = 5 });

            var testCollection = GetUserCollection();

            var actualBookCollection = userService.GetAllUsers();

            Assert.Equal((testCollection.Count() + 1), actualBookCollection.Count());
        }

        private void InitializeMock()
        {
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[0])).Returns(GetBookDTOCollection().ToList()[0]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[1])).Returns(GetBookDTOCollection().ToList()[1]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[2])).Returns(GetBookDTOCollection().ToList()[2]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[3])).Returns(GetBookDTOCollection().ToList()[3]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[4])).Returns(GetBookDTOCollection().ToList()[4]);

            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[0])).Returns(GetUserDTOCollection().ToList()[0]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[1])).Returns(GetUserDTOCollection().ToList()[1]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[2])).Returns(GetUserDTOCollection().ToList()[2]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[3])).Returns(GetUserDTOCollection().ToList()[3]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[4])).Returns(GetUserDTOCollection().ToList()[4]);

        }

        private IEnumerable<Book> GetBookCollection()
        {
            return new[]
            {
                new Book{Id = 1},
                new Book{Id = 2},
                new Book{Id = 3},
                new Book{Id = 4},
                new Book{Id = 5},
            };
        }

        private IEnumerable<BookDTO> GetBookDTOCollection()
        {
            return new[]
            {
                new BookDTO{Id = 1},
                new BookDTO{Id = 2},
                new BookDTO{Id = 3},
                new BookDTO{Id = 4},
                new BookDTO{Id = 5},
            };
        }

        private IEnumerable<User> GetUserCollection()
        {
            return new[]
            {
                new User{FirstName = "a"},
                new User{FirstName = "b"},
                new User{FirstName = "c"},
                new User{FirstName = "d"},
                new User{FirstName = "f"},
            };
        }

        private IEnumerable<UserDTO> GetUserDTOCollection()
        {
            return new[]
            {
                new UserDTO{FirstName = "a"},
                new UserDTO{FirstName = "b"},
                new UserDTO{FirstName = "c"},
                new UserDTO{FirstName = "d"},
                new UserDTO{FirstName = "f"},
            };
        }

    }
}
