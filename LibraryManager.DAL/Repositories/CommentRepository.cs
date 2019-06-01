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
    class CommentRepository: IRepository<Comment,int>
    {
        private readonly LibraryManagerContext _dbContext;
        public CommentRepository(LibraryManagerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Comment> GetAll()
        {
            return _dbContext.Comments
                .Include(b=>b.Book)
                .Include(u=>u.User)
                .ToList();
        }

        public Comment Get(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id==id);
        }

        public void Create(Comment comment)
        {
            _dbContext.Add(comment); 
        }

        public void Update(Comment comment)
        {
            _dbContext.Entry(comment).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var comment = Get(id);
            if (comment != null)
                _dbContext.Comments.Remove(comment);
        }
    }
}
