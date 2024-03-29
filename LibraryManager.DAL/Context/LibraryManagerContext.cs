﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DAL.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryManager.DAL.Context
{
    public sealed class LibraryManagerContext: IdentityDbContext<User>
    {
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<CustomList> CustomList { get; set; }
        public DbSet<ListBook> ListBook { get; set; }



        public LibraryManagerContext() { }

        public LibraryManagerContext(DbContextOptions<LibraryManagerContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureBookGenreRelations(builder);
            ConfigureBookLanguageRelations(builder);
            ConfigureUserBookRelations(builder);
            ConfigureListBookRelations(builder);
            //new AuthorConfiguration().Initialize(builder, builder.Entity<Author>());
            //new BookConfiguration().Initialize(builder, builder.Entity<Book>());
            //new UserConfiguration().Initialize(builder, builder.Entity<User>());
            //new GenreConfiguration().Initialize(builder, builder.Entity<Genre>());
            base.OnModelCreating(builder);
        }

        private void ConfigureBookGenreRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookGenre>().HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Book).WithMany(b => b.Genres).HasForeignKey(bg => bg.BookId);
            modelBuilder.Entity<BookGenre>().HasOne(bg => bg.Genre).WithMany(g => g.Books).HasForeignKey(bg => bg.GenreId);
        }

        private void ConfigureBookLanguageRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().HasKey(bl => new { bl.BookId, bl.LanguageId });
            modelBuilder.Entity<BookLanguage>().HasOne(bl => bl.Book).WithMany(b => b.Languages).HasForeignKey(bl => bl.BookId);
            modelBuilder.Entity<BookLanguage>().HasOne(bl => bl.Language).WithMany(l => l.Books).HasForeignKey(bl => bl.LanguageId);
        }

        private void ConfigureUserBookRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBook>().HasKey(ub => new { ub.UserId, ub.BookId });
            modelBuilder.Entity<UserBook>().HasOne(ub => ub.User).WithMany(u => u.WishList).HasForeignKey(ub => ub.UserId);
            modelBuilder.Entity<UserBook>().HasOne(ub => ub.Book).WithMany(b => b.Users).HasForeignKey(ub => ub.BookId);
        }

        private void ConfigureListBookRelations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListBook>().HasKey(lb => new {lb.BookId, lb.CustomListId});
            modelBuilder.Entity<ListBook>().HasOne(lb => lb.Book).WithMany(u => u.Lists).HasForeignKey(ub => ub.BookId);
            modelBuilder.Entity<ListBook>().HasOne(lb => lb.CustomList).WithMany(b=>b.Books).HasForeignKey(ub => ub.CustomListId);
        }

    }
}