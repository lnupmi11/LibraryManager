using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;

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

        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
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
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
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

        public void Update(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _unitOfWork.BookRepository.Update(book);
            _unitOfWork.Save();
        }
    }
}
