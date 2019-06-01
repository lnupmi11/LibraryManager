using AutoMapper;
using LibraryManager.BLL.Interfaces;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(CommentDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);
            _unitOfWork.CommentRepository.Create(comment);
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            _unitOfWork.CommentRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<CommentDTO> GetByBook(int id)
        {
            var comments = _unitOfWork.CommentRepository.GetAll().Where(x => x.BookId == id);
            var commentsDTO = new List<CommentDTO>();

            foreach (var comment in comments)
            {
                commentsDTO.Add(_mapper.Map<CommentDTO>(comment));
            }

            return commentsDTO;
        }

        public void Update(CommentDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);
            _unitOfWork.CommentRepository.Update(comment);
            _unitOfWork.Save();
        }
    }
}
