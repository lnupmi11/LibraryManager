using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryManager.DAL.Entities;

namespace LibraryManager.DAL.Seeding
{
    public class Seeder
    {
        public  void SeedAll(LibraryManagerContext context)
        {
            BookSeed(context);
            AuthorSeed(context);
            GenreSeed(context);
            LanguageSeed(context);
        }
        private async void BookSeed(LibraryManagerContext context)
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

        private List<Book> GetBookSeedItems()
        {
            List<Book> list = new List<Book>();
            list.Add(new Book()
            {
                Id = 1,
                Author = GetAuthorSeedItems().FirstOrDefault(x => x.LastName == "London"),
                AvailableLanguagesCollection = new List<Language>() { GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "English"), GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                GenresCollection = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Adventures") },
                NumberOfPages = 400,
                Rating = 8,
                Title = "White Fang"
            });
            list.Add(new Book()
            {
                Id = 2,
                Author = GetAuthorSeedItems().FirstOrDefault(x => x.LastName == "Remark"),
                AvailableLanguagesCollection = new List<Language>() { GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "German"), GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                GenresCollection = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Novel") },
                NumberOfPages = 300,
                Rating = 9,
                Title = "Three Comrades"
            });
            list.Add(new Book()
            {
                Id = 3,
                Author = GetAuthorSeedItems().FirstOrDefault(x => x.LastName == "London"),
                AvailableLanguagesCollection = new List<Language>() {  GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "English"), GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                GenresCollection = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Adventures" ) },
                NumberOfPages = 400,
                Rating = 8,
                Title = "Call of the wild"
            });
            list.Add(new Book()
            {
                Id = 4,
                Author = GetAuthorSeedItems().FirstOrDefault(x => x.LastName == "Verne"),
                AvailableLanguagesCollection = new List<Language>() { GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "French"), GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                GenresCollection = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Adventures") },
                NumberOfPages = 500,
                Rating = 7,
                Title = "The Mysterious Island"
            });
            list.Add(new Book()
            {
                Id = 5,
                Author = GetAuthorSeedItems().FirstOrDefault(x => x.LastName == "Conan-Doyle"),
                AvailableLanguagesCollection = new List<Language>() { GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "English"), GetLanguageSeedItems().FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                GenresCollection = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Detective") },
                NumberOfPages = 200,
                Rating = 8,
                Title = "Sherlock Holmes"
            });
            return list;
        }

        private async void AuthorSeed(LibraryManagerContext context)
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

        private List<Author> GetAuthorSeedItems()
        {
            List<Author> list = new List<Author>();
            list.Add(new Author()
            {
                FirstName = "Jack", LastName = "London", Id = 1, NumberOfWrittenBooks = 10 
            });
            list.Add(new Author()
            {
                 FirstName = "Maria", LastName = "Remark", Id = 2, NumberOfWrittenBooks = 5 
            });
            list.Add(new Author()
            {
                FirstName = "Jules", LastName = "Verne",Id = 3, NumberOfWrittenBooks = 15
            });
            list.Add(new Author()
            {
                FirstName = "Arthur", LastName = "Conan-Doyle", Id = 3, NumberOfWrittenBooks = 5
            });
            return list;
        }

        private async void GenreSeed(LibraryManagerContext context)
        {
            List<Genre> list = GetGenreSeedItems();
            foreach (var item in list)
            {
                if (context.Set<Genre>().Any(x => x.Id == item.Id))
                {
                    continue;
                }

                await context.Set<Genre>().AddAsync(item);
            }

            await context.SaveChangesAsync();
        }
        private List<Genre> GetGenreSeedItems()
        {
            List<Genre> list = new List<Genre>();
            list.Add(new Genre()
            {
                Id = 1,
                GenreName = "Adventures"
            });
            list.Add(new Genre()
            {
                Id = 1,
                GenreName = "Detective"
            });
            list.Add(new Genre()
            {
                Id = 1,
                GenreName = "Novel"
            });
            return list;
        }
        private async void LanguageSeed(LibraryManagerContext context)
        {
            List<Language> list = GetLanguageSeedItems();
            foreach (var item in list)
            {
                if (context.Set<Language>().Any(x => x.LanguageName == item.LanguageName))
                {
                    continue;
                }

                await context.Set<Language>().AddAsync(item);
            }

            await context.SaveChangesAsync();
        }
        private List<Language> GetLanguageSeedItems()
        {
            List<Language> list = new List<Language>();
            list.Add(new Language()
            {
               LanguageName = "Ukrainian"
            });
            list.Add(new Language()
            {
                LanguageName = "English"
            });
            list.Add(new Language()
            {
                LanguageName = "French"
            });
            list.Add(new Language()
            {
                LanguageName = "French"
            });
            return list;
        }
    }
}
