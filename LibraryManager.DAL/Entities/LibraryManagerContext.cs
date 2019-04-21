using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryManager.DAL.Entities
{
    public sealed class LibraryManagerContext: IdentityDbContext<User>
    {
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }


        public LibraryManagerContext() { }

        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new AuthorConfiguration().Initialize(builder, builder.Entity<Author>());
            new BookConfiguration().Initialize(builder, builder.Entity<Book>());
            new UserConfiguration().Initialize(builder, builder.Entity<User>());
            new GenreConfiguration().Initialize(builder, builder.Entity<Genre>());
            base.OnModelCreating(builder);
        }
    }
}
