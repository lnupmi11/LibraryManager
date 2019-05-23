using AutoMapper;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LibraryManager.BLL.Services
{
    public class GenreService:IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IUserService userService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
            _mapper = mapper;
        }

        public void Create(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            _unitOfWork.GenreRepository.Create(genre);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.GenreRepository.Delete(id);
            _unitOfWork.Save();
        }

        public GenreDTO Find(int id)
        {
            var genre = _unitOfWork.GenreRepository.Get(id);
            var genreDTO = _mapper.Map<GenreDTO>(genre);

            return genreDTO;
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            var genres = _unitOfWork.GenreRepository.GetAll();
            var genreDTOs = new List<GenreDTO>();

            foreach (var genre in genres)
            {
                genreDTOs.Add(_mapper.Map<GenreDTO>(genre));
            }

            return genreDTOs;
        }

        public void Update(GenreDTO genreDTO)
        {
            var genre = _mapper.Map<Genre>(genreDTO);
            _unitOfWork.GenreRepository.Update(genre);
            _unitOfWork.Save();
        }


    }
}
