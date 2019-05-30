using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Interfaces
{
    public interface IAuthorService
    {
        void Create(AuthorDTO authorDTO);
        void Delete(int id);
        IEnumerable<AuthorDTO> GetAll();
        void Update(AuthorDTO authorDTO);
    }
}
