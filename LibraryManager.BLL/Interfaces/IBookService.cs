using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Models;

namespace LibraryManager.BLL.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetAll();
        void Create(BookDTO BookDTO);
        BookDTO Find(int id);
        void Delete(int id);
        void Update(BookDTO BookDTO);

        bool isBookAlreadyInUserWishList(string userId, int bookId);
        void AddBookToWishList(string userId, int bookId);
        void DeleteBookFromWishList(string userId, int bookId);
    }
}
