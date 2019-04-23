using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Services
{
    public class LanguageService : ILanguageService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void Create(LanguageDTO languageDTO)
        {
            var language = _mapper.Map<Language>(languageDTO);
            _unitOfWork.LanguageRepository.Create(language);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.LanguageRepository.Delete(id);
            _unitOfWork.Save();
        }

        public LanguageDTO Find(int id)
        {
            var language = _unitOfWork.LanguageRepository.Get(id);
            var languageDTO = _mapper.Map<LanguageDTO>(language);

            return languageDTO;
        }

        public IEnumerable<LanguageDTO> GetAll()
        {
            var languages = _unitOfWork.LanguageRepository.GetAll();
            var languagesDTO = new List<LanguageDTO>();

            foreach (var language in languages)
            {
                languagesDTO.Add(_mapper.Map<LanguageDTO>(language));
            }

            return languagesDTO;
        }

        public void Update(LanguageDTO languageDTO)
        {
            var language = _mapper.Map<Language>(languageDTO);
            _unitOfWork.LanguageRepository.Update(language);
            _unitOfWork.Save();
        }

    }
}
