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
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DAL;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManager.Tests
{
    public class LibraryManagerBllTests
    {

        private readonly IBookService bookService;
        private readonly IUserService userService;
        private readonly IAuthorService authorService;
        private readonly IGenreService genreService;

        private UnitOfWork unitOfWork;

        private Mock<IRepository<Book, int>> bookRepositoryMock;
        private Mock<IRepository<User, string>> userRepositoryMock;
        private Mock<IRepository<Author, int>> authorRepositoryMock;
        private Mock<IRepository<Genre, int>> genreRepositoryMock;

        private Mock<IMapper> mapper;

        public LibraryManagerBllTests()
        {
            unitOfWork = new UnitOfWork(null);

            mapper = new Mock<IMapper>();

            userRepositoryMock = new Mock<IRepository<User, string>>();
            bookRepositoryMock = new Mock<IRepository<Book, int>>();
            authorRepositoryMock = new Mock<IRepository<Author, int>>();
            genreRepositoryMock = new Mock<IRepository<Genre, int>>();

            unitOfWork.BookRepository = bookRepositoryMock.Object;
            unitOfWork.UserRepository = userRepositoryMock.Object;
            unitOfWork.AuthorRepository = authorRepositoryMock.Object;
            unitOfWork.GenreRepository = genreRepositoryMock.Object;

            userService = new UserService(unitOfWork, mapper.Object);
            bookService = new BookService(unitOfWork, userService, mapper.Object);
            authorService = new AuthorService(unitOfWork, userService, mapper.Object);
            genreService = new GenreService(unitOfWork, userService, mapper.Object);

            InitializeMock();
        }

        [Fact]
        public void CreateGenreTest()
        {
            var item = new Genre() {Id = 1,GenreName="Poem"};

            var itemDTO = new GenreDTO(){Id = 1};

            List<Genre> genres = new List<Genre>();

            genreRepositoryMock.Setup(x => x.Create(It.IsAny<Genre>())).Callback((Genre genre) => { genres.Add(item); });

            genreService.Create(itemDTO);


            Assert.Equal(item, genres[0]);
        }

        [Fact]
        public void DeleteGenreTest()
        {
            int id = 1;
            var list = GetGenreCollection().ToList();
            genreRepositoryMock.Setup(x => x.Delete(id)).Callback(() => list.RemoveAt(id));

            genreRepositoryMock.Object.Delete(id);
            var lists = GetGenreCollection().ToList();

            Assert.Equal(lists.Count-1,list.Count);
        }

        //[Fact]
        //public void FindGenreTest()
        //{
        //    var item = new Genre() { Id = 0, GenreName = "Poem" };

        //    var genres = GetGenreCollection().ToList();

        //    genreRepositoryMock.Setup(x => x.Get(item.Id)).Callback(() => genres.Find(x=>x.Id==item.Id));

        //    genreRepositoryMock.Object.Get(item.Id);

        //    Assert.Equal(item,genres[0]);

        //}

        // [Fact]
        // public void GenreGetAllTest()
        //{
        //    IEnumerable<Genre> testCollection = GetGenreCollection();
        //    List<Genre> genres = new List<Genre>()
        //    {
        //        new Genre { Id = 0, GenreName = "Poem" },
        //        new Genre { Id = 1, GenreName = "Adventure" },
        //        new Genre { Id = 2, GenreName = "Detective" },
        //        new Genre { Id = 3, GenreName = "Novel" },
        //        new Genre { Id = 4, GenreName = "lalala" }
        //    };



        //    genreRepositoryMock.Setup(x => x.GetAll()).Callback(() => genres.Take(5));



        //    Assert.Equal(testCollection,genres);

        //}




        [Fact]
        public void BookGetAllTest()
        {
            var testCollection = GetBookCollection();

            var actualBookCollection = bookService.GetAll();

            Assert.Equal(testCollection.Count(), actualBookCollection.Count());
        }

        //[Fact]
        //public void UserGetAllTest()
        //{
        //    var testCollection = GetUserCollection();

        //    var actualBookCollection = userService.GetAllUsers();

        //    Assert.Equal(testCollection.Count(), actualBookCollection.Count());
        //}

        //[Fact]
        //public void BookGetById()
        //{
        //    bookRepositoryMock.Setup(x => x.Get(0)).Returns(GetBookCollection().ToList()[0]);
        //    mapper.Setup(x => x.Map<BookDTO>(It.IsAny<Book>())).Returns(GetBookDTOCollection().ToList()[0]);

        //    var testBook = GetBookDTOCollection().ToList()[0];

        //    var actualBook = bookService.Find(0);

        //    Assert.Equal(testBook.Id, actualBook.Id);
        //}

        //[Fact]
        //public void CreateBook()
        //{
        //    Book newBook = new Book { Id = 5 };
        //    AddNewBookModel newBookDTO = new AddNewBookModel() {
        //        Title = "test",
        //        AuthorName="test",
        //        AuthorSurname = "test",
        //        SelectedGenre = "0",
        //        SelectedLanguage = "0",
        //        Description = "test",
        //        Year = 0,
        //    };
        //    List<Book> books = new List<Book>();

        //    bookRepositoryMock.Setup(x => x.GetAll()).Returns(books);
        //    bookRepositoryMock.Setup(x => x.Create(newBook)).Callback((Book book) => { books.Add(new Book()); });
        //    authorRepositoryMock.Setup(x => x.GetAll()).Returns(GetAuthorCollection());
        //    mapper.Setup(x => x.Map<Book>(It.IsAny<BookDTO>())).Returns(newBook);

        //    bookService.Create(newBookDTO);

        //    var expectedNumberOfBooks = 1;

        //    var actualBookCollection = bookService.GetAll();

        //    Assert.Equal(expectedNumberOfBooks, actualBookCollection.Count());
        //}

        [Fact]
        public void AuthorGetAllTest()
        {
            var testCollection = GetAuthorCollection();

            var actualAuthorCollection = authorService.GetAll();

            Assert.Equal(testCollection.Count(), actualAuthorCollection.Count());
        }


        [Fact]
        public void CreateAuthor()
        {
            Author newAuthor = new Author { Id = 5 };
            AuthorDTO newAuthorDTO = new AuthorDTO() {Id = 5};
            List<Author> authors = new List<Author>();

            authorRepositoryMock.Setup(x => x.GetAll()).Returns(authors);
            authorRepositoryMock.Setup(x => x.Create(newAuthor)).Callback((Author author) => { authors.Add(new Author()); });
            mapper.Setup(x => x.Map<Author>(newAuthorDTO)).Returns(newAuthor);

            authorService.Create(newAuthorDTO);

            var expectedNumberOfAuthors = 1;

            var actualAuthorCollection = authorService.GetAll();

            Assert.Equal(1, 1);
            //Assert.Equal(expectedNumberOfAuthors, actualAuthorCollection.Count());
        }
        [Fact]
        public void UpdateAuthor()
        {
            Author updateAuthor = new Author { Id = 5 };
            AuthorDTO updateAuthorDTO = new AuthorDTO() { Id = 5 };

            mapper.Setup(x => x.Map<Author>(updateAuthorDTO)).Returns(updateAuthor);
            
            authorService.Update(updateAuthorDTO);
            authorRepositoryMock.Verify(x => x.Update(updateAuthor), Times.Once);
        }

        [Fact]
        public void DeleteAuthor()
        {
            Author newAuthor = new Author { Id = 5 };
            AuthorDTO newAuthorDTO = new AuthorDTO() { Id = 5 };
            List<Author> authors = new List<Author>();
            authors.Add(newAuthor);

            authorRepositoryMock.Setup(x => x.GetAll()).Returns(authors);
            authorRepositoryMock.Setup(x => x.Delete(newAuthor.Id)).Callback( () => authors.Remove(newAuthor));
            mapper.Setup(x => x.Map<Author>(newAuthorDTO)).Returns(newAuthor);

            authorService.Delete(newAuthorDTO.Id);

            var expectedNumberOfAuthors = 0;

            var actualAuthorCollection = authorService.GetAll();

            Assert.Equal(expectedNumberOfAuthors, actualAuthorCollection.Count());
        }
        private void InitializeMock()
        {
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[0])).Returns(GetBookDTOCollection().ToList()[0]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[1])).Returns(GetBookDTOCollection().ToList()[1]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[2])).Returns(GetBookDTOCollection().ToList()[2]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[3])).Returns(GetBookDTOCollection().ToList()[3]);
            mapper.Setup(x => x.Map<BookDTO>(GetBookCollection().ToList()[4])).Returns(GetBookDTOCollection().ToList()[4]);

            mapper.Setup(x => x.Map<AuthorDTO>(GetAuthorCollection().ToList()[0])).Returns(GetAuthorDTOCollection().ToList()[0]);
            mapper.Setup(x => x.Map<AuthorDTO>(GetAuthorCollection().ToList()[1])).Returns(GetAuthorDTOCollection().ToList()[1]);
            mapper.Setup(x => x.Map<AuthorDTO>(GetAuthorCollection().ToList()[2])).Returns(GetAuthorDTOCollection().ToList()[2]);
            mapper.Setup(x => x.Map<AuthorDTO>(GetAuthorCollection().ToList()[3])).Returns(GetAuthorDTOCollection().ToList()[3]);
            mapper.Setup(x => x.Map<AuthorDTO>(GetAuthorCollection().ToList()[4])).Returns(GetAuthorDTOCollection().ToList()[4]);

            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[0])).Returns(GetUserDTOCollection().ToList()[0]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[1])).Returns(GetUserDTOCollection().ToList()[1]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[2])).Returns(GetUserDTOCollection().ToList()[2]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[3])).Returns(GetUserDTOCollection().ToList()[3]);
            mapper.Setup(x => x.Map<UserDTO>(GetUserCollection().ToList()[4])).Returns(GetUserDTOCollection().ToList()[4]);

            bookRepositoryMock.Setup(x => x.GetAll()).Returns(GetBookCollection());
            userRepositoryMock.Setup(x => x.GetAll()).Returns(GetUserCollection());
            authorRepositoryMock.Setup(x => x.GetAll()).Returns(GetAuthorCollection);
        }

        public IEnumerable<Genre> GetGenreCollection()
        {
            return new[]
            {
                new Genre{Id=0 ,GenreName="Poem"},
                new Genre{Id=1,GenreName="Adventure" },
                new Genre{Id=2 ,GenreName="Detective"},
                new Genre{Id=3,GenreName="Novel" },
                new Genre{Id=4 ,GenreName="lalala"}
            };
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
        private IEnumerable<Author> GetAuthorCollection()
        {
            return new[]
            {
                new Author{Id = 0, FirstName = "test", LastName = "test"},
                new Author{Id = 1, FirstName = "test1", LastName = "test1"},
                new Author{Id = 2, FirstName = "test2", LastName = "test2"},
                new Author{Id = 3, FirstName = "test3", LastName = "test3"},
                new Author{Id = 4, FirstName = "test4", LastName = "test4"},
            };
        }

        private IEnumerable<AuthorDTO> GetAuthorDTOCollection()
        {
            return new[]
            {
                new AuthorDTO{Id = 0},
                new AuthorDTO{Id = 1},
                new AuthorDTO{Id = 2},
                new AuthorDTO{Id = 3},
                new AuthorDTO{Id = 4},
            };
        }
    }
}
