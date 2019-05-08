using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;
using LibraryManager.DTO.Models.Manage;

namespace LibraryManager.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        void Create(BookDTO bookDTO);
        BookDTO Find(int id);
        void Delete(int id);
        void Update(EditBookViewModel bookDTO);
    }
}
