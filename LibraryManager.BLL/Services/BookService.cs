using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models.Manage;
using LibraryManager.DTO.Models;
using System.Linq;
using System.Collections;

namespace LibraryManager.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }

        public void AddBookToWishList(string userId, int bookId)
        {
            var item = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (item == null)
            {
                item = new UserBook()
                {
                    UserId = userId,
                    BookId = bookId,
                    IsAlreadyFinished = false,
                    IsInWishList = true,
                    IsReading = false
                };
                _unitOfWork.UserBookRepository.Create(item);
                _unitOfWork.Save();
            }
            else //if (item.IsReading != true && item.IsAlreadyFinished != true)
            {
                item.IsInWishList = true;
                _unitOfWork.UserBookRepository.Update(item);
                _unitOfWork.Save();
            }
        }

        public bool IsBookFinished(string userId, int bookId)
        {  
           var  item = _unitOfWork.UserBookRepository.Get(userId, bookId); 
           if(item!=null)
            {
                return item.IsAlreadyFinished;
            }
            return false;
        }
        public void DeleteBookFromWishList(string userId, int bookId)
        {
            var isBookAlreadyInWishList = isBookAlreadyInUserWishList(userId, bookId);
            if (isBookAlreadyInWishList)
            {
                var item = _unitOfWork.UserBookRepository.Get(userId, bookId);
                item.IsInWishList = false;
                _unitOfWork.UserBookRepository.Update(item);
                _unitOfWork.Save();
            }
        }

        public bool isBookAlreadyInUserWishList(string userId, int bookId)
        {
            var userBookRecord = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBookRecord  != null )
            {
                return userBookRecord.IsInWishList;
            }
            return false;
        }


        private IEnumerable<BookDTO> getBooks(string userId)
        {

            var books = from ubook in _unitOfWork.UserBookRepository.GetAll().
                             Where(x=>x.UserId == userId)
                        join
                        book in _unitOfWork.BookRepository.GetAll()
                        on ubook.BookId equals book.Id
                        select new
                        {
                            Book = book,
                            IsFinished = ubook.IsAlreadyFinished
                        };


            var booksDTO = new List<BookDTO>();

            foreach (var book in books)
            {
                booksDTO.Add(CustomBookMapper(book.Book, book.IsFinished));
            }
            return booksDTO.ToList();
        }

        public void Create(AddNewBookModel bookModel)
        {

            var bookDTO = CreateBookModelToDTO(bookModel);
            var book = _mapper.Map<Book>(bookDTO);
            book.Author =
                _unitOfWork.AuthorRepository.GetAll().FirstOrDefault(a => a.FirstName == bookModel.AuthorName && a.LastName == bookModel.AuthorSurname) ??
                new Author() {FirstName = bookModel.AuthorName, LastName = bookModel.AuthorSurname};
           
            book.Languages = new List<BookLanguage> { new BookLanguage() { BookId=book.Id,LanguageId=bookDTO.Languages.FirstOrDefault().Id} };


            book.Genres = new List<BookGenre>();
            foreach (var genre in bookModel.SelectedGenre)
            {
                book.Genres.Add(new BookGenre()
                {
                    BookId = book.Id,
                    GenreId = int.Parse(genre)
                });

            }
            _unitOfWork.BookRepository.Create(book);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.BookRepository.Delete(id);
            _unitOfWork.Save();
        }

        public BookDTO Find(int id)
        {
            var book = _unitOfWork.BookRepository.Get(id);
            var BookDTO = _mapper.Map<BookDTO>(book);

            return BookDTO;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var books = _unitOfWork.BookRepository.GetAll();
            var booksDTO = new List<BookDTO>();

            foreach (var book in books)
            {
                booksDTO.Add(_mapper.Map<BookDTO>(book));
            }

            return booksDTO;
        }

        public BookDTO CreateBookModelToDTO(AddNewBookModel addNewBookModel)
        {
            List<GenreDTO> genres = new List<GenreDTO>();
            foreach (var genre in addNewBookModel.SelectedGenre)
            {
                genres.Add(new GenreDTO() { Id = int.Parse((genre)) });
            }

            BookDTO bookDTO = new BookDTO
            {
                Title = addNewBookModel.Title,
                Author = new AuthorDTO() { FirstName = addNewBookModel.AuthorName },
                Genres=genres,
                ////////////Genres = new List<GenreDTO>()
                ////////////{
                ////////////    new GenreDTO()
                ////////////    {
                ////////////        Id = int.Parse((addNewBookModel.SelectedGenre[0]))
                ////////////    }
                ////////////},
                Languages = new List<LanguageDTO>() { new LanguageDTO() {Id=int.Parse((addNewBookModel.SelectedLanguage)) } },
                Description = addNewBookModel.Description,
                NumberOfPages = addNewBookModel.NumberOfPages,
                Year = addNewBookModel.Year
            };
            return bookDTO;
        }

        public BookDTO EditBookModelToDTO(EditBookViewModel addNewBookModel)
        {
            BookDTO bookDTO = new BookDTO
            {
                Id = addNewBookModel.Id,
                Title = addNewBookModel.Title,
                Author = new AuthorDTO() { FirstName = addNewBookModel.AuthorName, LastName = addNewBookModel.AuthorSurname},
                Genres = new List<GenreDTO>(),
                Languages = new List<LanguageDTO>(),
                Description = addNewBookModel.Description,
                Rating = addNewBookModel.Rating,
                NumberOfPages = addNewBookModel.NumberOfPages,
                Year = addNewBookModel.Year
            };
            return bookDTO;
        }

        public EditBookViewModel EditBookDTOToModel(BookDTO bookDTO)
        {
            EditBookViewModel bookModel = new EditBookViewModel
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                AuthorName = bookDTO.Author.FirstName,
                AuthorSurname = bookDTO.Author.LastName,
                //Genres = new List<GenreDTO>() { new GenreDTO() { Id = int.Parse((addNewBookModel.SelectedGenre)) } },
                //Languages = new List<LanguageDTO>(),
                Description = bookDTO.Description,
                Rating = bookDTO.Rating,
                NumberOfPages = bookDTO.NumberOfPages,
                Year = bookDTO.Year
            };
            return bookModel;
        }


        public void Update(EditBookViewModel bookModel)
        {
            var bookDTO = EditBookModelToDTO(bookModel);
            var book = _mapper.Map<Book>(bookDTO);
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
        }

        public BookDTO GetRandom()
        {
            var books = GetAll().ToList();
            var random = new Random();
            var index = random.Next(0, books.Count());
            var randomBook = books[index];

            return randomBook;
        }

        public IEnumerable<BookDTO> BooksFromUserLibrary(string userId)
        {

            var books = from ubook in _unitOfWork.UserBookRepository.GetAll().
                             Where(x=>x.IsReading==true && x.IsInWishList ==false && x.UserId == userId)
                             join
                             book in _unitOfWork.BookRepository.GetAll()
                             on ubook.BookId equals book.Id
                             select new 
                             {
                                 Book = book,
                                 IsFinished = ubook.IsAlreadyFinished
                             };


            var booksDTO = new List<BookDTO>();
           
             foreach(var book in books)
            {
                booksDTO.Add(CustomBookMapper(book.Book,book.IsFinished));
            }
            return booksDTO.ToList();
        }
        
        public void FinishReadingBook(string userId, int bookId)
        {
            var userBook = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if(userBook != null)
            {
                userBook.IsAlreadyFinished = true;
                _unitOfWork.UserBookRepository.Update(userBook);
                _unitOfWork.Save();
            }
        }

        public bool DoesUserReadsBook(string userId,int bookId)
        {
           var userBook =  _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBook!= null)
            {
                return userBook.IsReading;
            }
            return false;
        }

        public void StartReadingBook(string userId, int bookId)
        {
            var userBook = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBook == null)
            {   
                var itemToCreate = new UserBook()
                {
                    BookId = bookId,
                    UserId = userId,
                    IsReading = true,
                    IsInWishList = false
                };

                _unitOfWork.UserBookRepository.Create(itemToCreate);
            }
            else //if(userBook.IsAlreadyFinished!=true)
            {
                userBook.IsReading = true;
              
                _unitOfWork.UserBookRepository.Update(userBook);
                _unitOfWork.Save();
            }
        }

        public void StopReadingBook(string userId, int bookId)
        {
            var item = _unitOfWork.UserBookRepository.Get(userId, bookId);
            item.IsReading = false;
            _unitOfWork.UserBookRepository.Update(item);
            _unitOfWork.Save();
        }

        public float GetAlreadyReadBooksPercentage(string userId)
        {
            var userBooks = BooksFromUserLibrary(userId);

            float countOfReadBooks = 0;

            foreach(var userbook in userBooks)
            {
                if (userbook.IsFinished)
                {
                    countOfReadBooks++;
                }
            }
            if (countOfReadBooks != 0 && userBooks.Count() != 0)
            {
                return countOfReadBooks / userBooks.Count();
            }
            return 0;
        }

        private BookDTO CustomBookMapper(Book book, bool isFinished)
        {
            return new BookDTO
            {
                Id = book.Id,
                Author = _mapper.Map<AuthorDTO>(book.Author),
                Description = book.Description,
                
                Year = book.Year,
                 
                NumberOfPages = book.NumberOfPages,
                Rating = book.Rating,
                Title = book.Title,
                IsFinished = isFinished,
                
            };
        }

        public IEnumerable<BookDTO> GetBooksFromWishList(string userId)
        {
           var books = getBooks(userId);
           var wishedBooks = new List<BookDTO>();
           foreach(var book in books)
            {
               if(isBookAlreadyInUserWishList(userId,book.Id))
                    {
                        wishedBooks.Add(book);
                    }
            }
            return wishedBooks;
        }

        public Dictionary<string, int> GetUserBooksByGenreStatistics(string userId)
        {
            var books = getBooks(userId)
                .Where(book=>book.IsFinished==true).ToList();

            Dictionary<string, int> dictionary = new Dictionary<string,int>();
           
            foreach(var book in books)
            {
                foreach (var genre in book.Genres)
                {
                    if (dictionary.ContainsKey(genre.GenreName))
                    {
                        dictionary[genre.GenreName]++;
                    }
                    else
                    {
                        dictionary[genre.GenreName] = 1;
                    }
                }
            }
            return dictionary;
        }

        public bool IsBookRated(string userId, int bookId)
        {
            var userBookItem = _unitOfWork.UserBookRepository.Get(userId, bookId);

            if (userBookItem == null)
                return false;

            return userBookItem.IsRated;
        }

        public void RateBook(string userId, int bookId)
        {
            var userBookItem = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBookItem == null)
            {
                userBookItem = CreateNewUserBookItem(userId, bookId);
            }

            userBookItem.IsRated = userBookItem.IsRated ? false : true;
            _unitOfWork.UserBookRepository.Update(userBookItem);
            _unitOfWork.Save();

            ChangeBookRatng(bookId);
        }


        private void ChangeBookRatng(int bookId)
        {
            var maxRating = 5.0;
            var book = _unitOfWork.BookRepository.Get(bookId);
            var numberOfAllUsers = _unitOfWork.UserRepository.GetAll().ToList().Count;
            var numberOfUsersWhoRatedBook = _unitOfWork.UserBookRepository.GetAll().Where(ub => ub.BookId == bookId && ub.IsRated).Count();

            book.Rating = maxRating * ((double)numberOfUsersWhoRatedBook / numberOfAllUsers);

            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
        }
        private UserBook  CreateNewUserBookItem(string userId, int bookId)
        {
            var newUserBook = new UserBook
            {
                UserId = userId,
                BookId = bookId
            };

            _unitOfWork.UserBookRepository.Create(newUserBook);
            _unitOfWork.Save();

            newUserBook = _unitOfWork.UserBookRepository.Get(userId, bookId);
            return newUserBook;
        }






        public void CreateCustomListForUser(string userId, string customListName)
        {
            var item = new CustomList()
            {
                Name = customListName,
                UserId = userId
            };
            _unitOfWork.CustomListRepository.Create(item);
            _unitOfWork.Save();
        }

        public void DeleteCustomList(int id)
        {
            _unitOfWork.CustomListRepository.Delete(id);
            _unitOfWork.Save();
        }

        public void AddBookToCustomList(int customListId, int bookId)
        {
            var item = _unitOfWork.BookRepository.Get(bookId);
            var listBook = new ListBook()
            {
                BookId = bookId,
                CustomListId = customListId
            };
            _unitOfWork.ListBookRepository.Create(listBook);
            _unitOfWork.Save();
        }

        public void DeleteBookFromCustomList(int customListId, int bookId)
        {
            _unitOfWork.ListBookRepository.Delete(customListId,bookId);
        }

        public IEnumerable<CustomList> GetUserCustomLists(string userId)
        {
            var all = _unitOfWork.CustomListRepository.GetAll()
                .Where(x => x.UserId == userId);
            return all;
        }

        public  CustomList  OpenCustomList(int id)
        {
            var all = _unitOfWork.ListBookRepository.GetAll()
                .Where(x => x.CustomListId == id).ToList();

            var bookIds = new List<int>();
            foreach (var listbook in all)
            {
                bookIds.Add(listbook.BookId);
            }
            var item = _unitOfWork.CustomListRepository.Get(id);

           
          return item;
        }
    }
}
