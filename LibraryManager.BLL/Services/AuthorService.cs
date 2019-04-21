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
    public class AuthorService// : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> authorRepository, IUserService userService, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public void Create(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _authorRepository.Create(author);
        }

        public void Delete(int id)
        {
            _authorRepository.Delete(id);
        }

        public AuthorDTO Find(int id)
        {
            var author = _authorRepository.Get(id);
            var authorDTO = _mapper.Map<AuthorDTO>(author);

            return authorDTO;
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var authors = _authorRepository.GetAll();
            var authorsDTO = new List<AuthorDTO>();

            foreach (var author in authors)
            {
                authorsDTO.Add(_mapper.Map<AuthorDTO>(author));
            }

            return authorsDTO;
        }

        public void Update(AuthorDTO authorDTO)
        {
            var book = _mapper.Map<Author>(authorDTO);
            _authorRepository.Update(book);
        }
    }
}
