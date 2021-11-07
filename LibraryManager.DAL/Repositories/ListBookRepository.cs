using LibraryManager.DAL.Context;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.DAL.Repositories
{
    public class ListBookRepository : IManyToManyRepository<ListBook, int, int>
    {
        private readonly LibraryManagerContext _dbContext;
        private readonly CustomListRepository _customListRepository;
        private readonly BookRepository _bookRepository;

        public ListBookRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
            _bookRepository = new BookRepository(dbContext);
            
        }

        public IQueryable<ListBook> GetAll()
        {
            return _dbContext.ListBook;
        }
        //REMAKE TO LINQ!
        public IEnumerable<ListBook> GetAllAppropriate(int customListId, int bookId)
        {
            var listbooks = _dbContext.ListBook.ToList();
            var result = new List<ListBook>();
            foreach (var listbook in listbooks)
            {
                if (listbook.CustomListId == customListId && listbook.BookId == bookId)
                {
                    result.Add(listbook);
                }
            }
            return result;
        }

        public ListBook Get(int customListId, int bookId)
        {
            var listBook = _dbContext.ListBook.FirstOrDefault(x => x.CustomListId == customListId && x.BookId == bookId);
            return listBook;
        }

        public void Create(ListBook item)
        {
            _dbContext.Add(item);
        }

        public void Update(ListBook item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int customListId, int bookId)
        {
            var item = Get(customListId, bookId);
            if (item != null)
                _dbContext.ListBook.Remove(item);
        }
    }
}
