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
            var isBookAlreadyInWishList = isBookAlreadyInUserWishList(userId, bookId);
            if (!isBookAlreadyInWishList)
            {
                _unitOfWork.UserBookRepository.Create(new UserBook
                {
                    UserId = userId,
                    BookId = bookId
                });
            }
        }

        public void DeleteBookFromWishList(string userId, int bookId)
        {
            var isBookAlreadyInWishList = isBookAlreadyInUserWishList(userId, bookId);
            if (isBookAlreadyInWishList)
            {
                _unitOfWork.UserBookRepository.Delete(userId, bookId);
            }
        }

        public bool isBookAlreadyInUserWishList(string userId, int bookId)
        {
            var userBookRecord = _unitOfWork.UserBookRepository.Get(userId, bookId);
            //Even if record is deleted we receive model but the fields are 0 ro null.
            //Consider about changing this condition.
            if (userBookRecord.BookId != 0)
            {
                return true;
            }
            return false;
        }

        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(BookDTO);
            _unitOfWork.BookRepository.Create(book);
            _unitOfWork.Save();

            var _book=_unitOfWork.BookRepository.GetAll().Where(x => x.Title == BookDTO.Title).FirstOrDefault();

            BookGenre bookGenre = new BookGenre() { BookId = _book.Id, GenreId = BookDTO.Genres.FirstOrDefault().Id };

            _unitOfWork.BookGenreRepository.Create(bookGenre);
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

        public void Update(EditBookViewModel bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
        }
    }
}
