using LibraryManager.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.BLL.Interfaces
{
    interface IGenreService
    {
        void Create(GenreDTO genreDTO);
        IEnumerable<GenreDTO> GetAll();
        void Update(GenreDTO genreDTO);
        void Delete(int id);
        GenreDTO Find(int id);
    }
}
