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
    public class AuthorService: IAuthorService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }

        public void Create(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _unitOfWork.AuthorRepository.Create(author);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.AuthorRepository.Delete(id);
            _unitOfWork.Save();
        }

        public AuthorDTO Find(int id)
        {
            var author = _unitOfWork.AuthorRepository.Get(id);
            var authorDTO = _mapper.Map<AuthorDTO>(author);

            return authorDTO;
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            var authors = _unitOfWork.AuthorRepository.GetAll();
            var authorsDTO = new List<AuthorDTO>();

            foreach (var author in authors)
            {
                authorsDTO.Add(_mapper.Map<AuthorDTO>(author));
            }

            return authorsDTO;
        }

        public void Update(AuthorDTO authorDTO)
        {
            var author = _mapper.Map<Author>(authorDTO);
            _unitOfWork.AuthorRepository.Update(author);
            _unitOfWork.Save();
        }
    }
}
