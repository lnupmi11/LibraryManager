using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Entities
{
    class LibraryManagerContext: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book>Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<User> Users { get; set; }


        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
