using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DAL.Seeding
{
    public class Seeder
    {
        public async void BookSeed(LibraryManagerContext context)
        {
            List<Book> list = GetBookSeedItems();
            foreach (var item in list)
            {
                if (context.Set<Book>().Any(x => x.Id == item.Id))
                {
                    continue;
                }

                await context.Set<Book>().AddAsync(item);
            }

            await context.SaveChangesAsync();
        }

        public List<Book> GetBookSeedItems()
        {
            List<Book> list = new List<Book>();
            list.Add(new Book()
            {
                Id = 1,
                Author = new Author() { FirstName = "Jack", LastName = "London", Id = 1, NumberOfWrittenBooks = 10 },
                AvailableLanguagesCollection = new List<Language>() { new Language() { LanguageName = "Ukrainian" }, new Language() { LanguageName = "English" } },
                GenresCollection = new List<Genre>() { new Genre() { GenreName = "Adventures" } },
                NumberOfPages = 400,
                Rating = 8,
                Title = "White Fang"
            });
            list.Add(new Book()
            {
                Id = 2,
                Author = new Author() { FirstName = "Maria", LastName = "Remark", Id = 2, NumberOfWrittenBooks = 5 },
                AvailableLanguagesCollection = new List<Language>() { new Language() { LanguageName = "Ukrainian" }, new Language() { LanguageName = "German" } },
                GenresCollection = new List<Genre>() { new Genre() { GenreName = "Novel" } },
                NumberOfPages = 300,
                Rating = 9,
                Title = "Three Comrades"
            });
            return list;
        }

        public async void AuthorSeed(LibraryManagerContext context)
        {
            List<Author> list = GetAuthorSeedItems();
            foreach (var item in list)
            {
                if (context.Set<Author>().Any(x => x.Id == item.Id))
                {
                    continue;
                }

                await context.Set<Author>().AddAsync(item);
            }

            await context.SaveChangesAsync();
        }

        public List<Author> GetAuthorSeedItems()
        {
            List<Author> list = new List<Author>();
            list.Add(new Author()
            {
                FirstName = "Jack",
                LastName = "London",
                Id = 1,
                NumberOfWrittenBooks = 10
            });
            list.Add(new Author()
            {
                FirstName = "Maria",
                LastName = "Remark",
                Id = 2,
                NumberOfWrittenBooks = 5
            });
            return list;
        }
    }
}
}
