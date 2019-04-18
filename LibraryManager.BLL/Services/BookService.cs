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
        private readonly IRepository<Book> _bookRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> bookRepository, IUserService userService, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public void Create(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _bookRepository.Create(book);
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }

        public BookDTO Find(int id)
        {
            var book = _bookRepository.Get(id);
            var bookDTO = _mapper.Map<BookDTO>(book);

            return bookDTO;
        }

        public IEnumerable<BookDTO> GetAll()
        {
            var books = _bookRepository.GetAll();

            return books;
        }

        public void Update(BookDTO bookDTO)
        {
            var book = _mapper.Map<Book>(bookDTO);
            _bookRepository.Update(book);
        }
    }
}
