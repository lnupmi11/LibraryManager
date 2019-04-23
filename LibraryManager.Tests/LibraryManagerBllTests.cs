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
using LibraryManager.DAL;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryManager.Tests
{
    public class LibraryManagerBllTests
    {
        private readonly IBookService bookService;
        private readonly IUserService userService;
        private UnitOfWork unitOfWork;
        private Mock<IRepository<Book, int>> bookRepositoryMock;
        private Mock<IRepository<User, string>> userRepositoryMock;
        private Mock<IMapper> mapper;

        public LibraryManagerBllTests()
        {
            unitOfWork = new UnitOfWork(null);
            mapper = new Mock<IMapper>();
            userRepositoryMock = new Mock<IRepository<User, string>>();
            bookRepositoryMock = new Mock<IRepository<Book, int>>();
            unitOfWork.BookRepository = bookRepositoryMock.Object;
            unitOfWork.UserRepository = userRepositoryMock.Object;
            userService = new UserService(unitOfWork, mapper.Object);
            bookService = new BookService(unitOfWork, userService, mapper.Object);

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
            bookRepositoryMock.Setup(x => x.Get(0)).Returns(GetBookCollection().ToList()[0]);

            var testBook = GetBookDTOCollection().ToList()[0];

            var actualBook = bookService.Find(0);

            Assert.Equal(testBook.Id, actualBook.Id);
        }

        [Fact]
        public void CreateBook()
        {
            Book newBook = new Book { Id = 5 };
            BookDTO newBookDTO = new BookDTO { Id = 5 };
            List<Book> books = new List<Book>();
            bookRepositoryMock.Setup(x => x.GetAll()).Returns(books);
            bookRepositoryMock.Setup(x => x.Create(newBook)).Callback((Book book) => { books.Add(new Book()); });
            mapper.Setup(x => x.Map<Book>(newBookDTO)).Returns(newBook);

            bookService.Create(newBookDTO);

            var expectedNumberOfBooks = 1;

            var actualBookCollection = bookService.GetAll();

            Assert.Equal(expectedNumberOfBooks, actualBookCollection.Count());
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

            bookRepositoryMock.Setup(x => x.GetAll()).Returns(GetBookCollection());
            userRepositoryMock.Setup(x => x.GetAll()).Returns(GetUserCollection());
        }

        private IEnumerable<Book> GetBookCollection()
        {
            return new[]
            {
                new Book{Id = 0},
                new Book{Id = 1},
                new Book{Id = 2},
                new Book{Id = 3},
                new Book{Id = 4},
            };
        }

        private IEnumerable<BookDTO> GetBookDTOCollection()
        {
            return new[]
            {
                new BookDTO{Id = 0},
                new BookDTO{Id = 1},
                new BookDTO{Id = 2},
                new BookDTO{Id = 3},
                new BookDTO{Id = 4},
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
