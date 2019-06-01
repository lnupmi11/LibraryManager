using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BLL.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentDTO commentDTO);
        void Delete(int id);
        IEnumerable<CommentDTO> GetByBook(int id);
        void Update(CommentDTO commentDTO);
    }
}
