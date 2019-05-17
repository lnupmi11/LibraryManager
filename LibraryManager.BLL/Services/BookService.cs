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
            if (item.IsReading != true)
            {
                if (item.UserId != null)
                {
                    item.IsInWishList = true;
                    _unitOfWork.UserBookRepository.Update(item);
                    _unitOfWork.Save();
                }
                else
                {
                    _unitOfWork.UserBookRepository.Create(new UserBook
                    {
                        UserId = userId,
                        BookId = bookId,
                        IsInWishList = true,
                        IsReading = false
                    });
                    _unitOfWork.Save();
                }
            }
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
            //Even if record is deleted we receive model but the fields are 0 ro null.
            //Consider about changing this condition.
            if (userBookRecord  != null)
            {
                return userBookRecord.IsInWishList;
            }
            return false;
        }

        public void Create(AddNewBookModel bookModel)
        {
            var bookDTO = CreateBookModelToDTO(bookModel);
            var book = _mapper.Map<Book>(bookDTO);
            book.Author =
                _unitOfWork.AuthorRepository.GetAll().FirstOrDefault(a => a.FirstName == bookModel.AuthorName && a.LastName == bookModel.AuthorSurname) ??
                new Author() {FirstName = bookModel.AuthorName, LastName = bookModel.AuthorSurname};
            book.Genres = new List<BookGenre>() { new BookGenre() { BookId = book.Id, GenreId = bookDTO.Genres.FirstOrDefault().Id } };

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
            BookDTO bookDTO = new BookDTO
            {
                Title = addNewBookModel.Title,
                Author = new AuthorDTO() { FirstName = addNewBookModel.AuthorName },
                Genres = new List<GenreDTO>() { new GenreDTO() { Id = int.Parse((addNewBookModel.SelectedGenre)) } },
                Languages = new List<LanguageDTO>(),
                Description = addNewBookModel.Description,
                Rating = addNewBookModel.Rating,
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
                             Where(x => x.IsReading == true && x.UserId == userId)
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
                booksDTO.Add(customBookMapper(book.Book,book.IsFinished));
            }
            return booksDTO.ToList();
        }
        
        public void FinishReadingBook(string userId, int bookId)
        {
            var userBook = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if(userBook.UserId != null)
            {
                userBook.IsAlreadyFinished = true;
                _unitOfWork.UserBookRepository.Update(userBook);
                _unitOfWork.Save();
            }
        }

        public bool DoesUserReadsBook(string userId,int bookId)
        {
           var userBook =  _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBook.UserId != null)
            {
                return userBook.IsReading;
            }
            return false;
        }

        public void StartReadingBook(string userId, int bookId)
        {
            var userBook = _unitOfWork.UserBookRepository.Get(userId, bookId);
            if (userBook.UserId == null)
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
            else
            {
                userBook.IsReading = true;
                userBook.IsInWishList = false;
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
           
            var userBooks = _unitOfWork.UserBookRepository.GetAll().
                Where(x => x.UserId == userId && x.BookId == 3);

            var userBooks1 = BooksFromUserLibrary(userId);

            int countOfReadBooks = 0;

            foreach(var userbook in userBooks)
            {
                if (userbook.IsAlreadyFinished)
                {
                    countOfReadBooks++;
                }
            }

            return countOfReadBooks / userBooks.Count();
        }

        public BookDTO customBookMapper(Book book, bool isFinished)
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

    }
}
