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
        void Create(AddNewBookModel bookModel);
        BookDTO Find(int id);
        void Delete(int id);
        void Update(EditBookViewModel bookDTO);
        bool isBookAlreadyInUserWishList(string userId, int bookId);
        void AddBookToWishList(string userId, int bookId);
        void DeleteBookFromWishList(string userId, int bookId);
        EditBookViewModel EditBookDTOToModel(BookDTO bookDTO);
    }
}
