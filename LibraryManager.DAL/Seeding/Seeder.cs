using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;

namespace LibraryManager.DAL.Seeding
{
    public static class Seeder
    {
        public static void SeedAll(LibraryManagerContext context)
        {
            AuthorSeed(context).GetAwaiter().GetResult();
            GenreSeed(context).GetAwaiter().GetResult();
            LanguageSeed(context).GetAwaiter().GetResult();
            BookSeed(context).GetAwaiter().GetResult();
            BookLanguageSeed(context).GetAwaiter().GetResult();
            BookGenreSeed(context).GetAwaiter().GetResult();
        }
        private static async Task BookSeed(LibraryManagerContext context)
        {
            if (!context.Set<Book>().Any())
            {
                List<Book> list = GetBookSeedItems(context);
                foreach (var item in list)
                {
                    if (context.Set<Book>().Any(x => x.Title == item.Title))
                    {
                        continue;
                    }

                    await context.Set<Book>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }

        public static List<Book> GetBookSeedItems(LibraryManagerContext context)
        {
            List<Book> list = new List<Book>();
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "London"),
                //Languages = new List<Language>() { context.Languages.FirstOrDefault(x => x.LanguageName == "English"), context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                //Genres = new List<BookGenre>() {  context.Genres.FirstOrDefault(x => x.GenreName == "Novel") },
                //GenreId = 3,
                //LanguageId = 1,
                NumberOfPages = 400,
                Rating = 8,
                Title = "White Fang"
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Remark"),
                //Languages = new List<Language>() { context.Languages.FirstOrDefault(x => x.LanguageName == "German"), context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                //Genres = new List<Genre>() { GetGenreSeedItems().FirstOrDefault(x => x.GenreName == "Novel") },
                //GenreId = 1,
                //LanguageId = 2,
                NumberOfPages = 300,
                Rating = 9,
                Title = "Three Comrades"
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "London"),
                //Languages = new List<Language>() { context.Languages.FirstOrDefault(x => x.LanguageName == "English"), context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                //Genres = new List<Genre>() { context.Genres.FirstOrDefault(x => x.GenreName == "Adventures") },
                //GenreId = 2,
                //LanguageId = 2,
                NumberOfPages = 400,
                Rating = 8,
                Title = "Call of the wild"
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Verne"),
                //Languages = new List<Language>() { context.Languages.FirstOrDefault(x => x.LanguageName == "French"), context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                //Genres = new List<Genre>() { context.Genres.FirstOrDefault(x => x.GenreName == "Adventures") },
                //GenreId = 2,
                //LanguageId = 1,
                NumberOfPages = 500,
                Rating = 7,
                Title = "The Mysterious Island"
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Conan-Doyle"),
                //Languages = new List<Language>() { context.Languages.FirstOrDefault(x => x.LanguageName == "English"), context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian") },
                //Genres = new List<Genre>() { context.Genres.FirstOrDefault(x => x.GenreName == "Detective") },
                //GenreId = 1,
                //LanguageId = 1,
                NumberOfPages = 200,
                Rating = 8,
                Title = "Sherlock Holmes"
            });
            return list;
        }

        private static async Task AuthorSeed(LibraryManagerContext context)
        {
            if (!context.Set<Author>().Any())
            {
                List<Author> list = GetAuthorSeedItems();
                foreach (var item in list)
                {
                    if (context.Set<Author>().Any(x => x.LastName == item.LastName))
                    {
                        continue;
                    }

                    await context.Set<Author>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }

        public static List<Author> GetAuthorSeedItems()
        {
            List<Author> list = new List<Author>();
            list.Add(new Author()
            {
                FirstName = "Jack",
                LastName = "London",
                NumberOfWrittenBooks = 10
            });
            list.Add(new Author()
            {
                FirstName = "Maria",
                LastName = "Remark",
                NumberOfWrittenBooks = 5
            });
            list.Add(new Author()
            {
                FirstName = "Jules",
                LastName = "Verne",
                NumberOfWrittenBooks = 15
            });
            list.Add(new Author()
            {
                FirstName = "Arthur",
                LastName = "Conan-Doyle",
                NumberOfWrittenBooks = 5
            });
            return list;
        }

        private static async Task GenreSeed(LibraryManagerContext context)
        {
            if (!context.Set<Genre>().Any())
            {
                List<Genre> list = GetGenreSeedItems();
                foreach (var item in list)
                {
                    await context.Set<Genre>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }
        public static List<Genre> GetGenreSeedItems()
        {
            List<Genre> list = new List<Genre>();
            list.Add(new Genre()
            {
                GenreName = "Adventures"
            });
            list.Add(new Genre()
            {
                GenreName = "Detective"
            });
            list.Add(new Genre()
            {
                GenreName = "Novel"
            });
            return list;
        }
        private static async Task LanguageSeed(LibraryManagerContext context)
        {
            if (!context.Set <Language>().Any())
            {
                List<Language> list = GetLanguageSeedItems();
                foreach (var item in list)
                {
                    await context.Set<Language>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }
        public static List<Language> GetLanguageSeedItems()
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
                LanguageName = "German"
            });
            return list;
        }

        private static async Task BookGenreSeed(LibraryManagerContext context)
        {
            if (!context.Set<BookGenre>().Any())
            {
                var list = GetBookGenreSeedItems(context);
                foreach (var item in list)
                {
                    await context.Set<BookGenre>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }

        public static List<BookGenre> GetBookGenreSeedItems(LibraryManagerContext context)
        {
            var list = new List<BookGenre>()
            {
                new BookGenre() {
                    Book = context.Books.FirstOrDefault(b => b.Title == "White Fang"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Novel")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Three Comrades"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Novel")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Call of the wild"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Adventures")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Mysterious Island"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Adventures")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Sherlock Holmes" ),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Detective")
                }
            };
            return list;
        }

        private static async Task BookLanguageSeed(LibraryManagerContext context)
        {
            if (!context.Set<BookLanguage>().Any())
            {
                var list = GetBookLanguageSeedItems(context);
                foreach (var item in list)
                {
                    await context.Set<BookLanguage>().AddAsync(item);
                }

                await context.SaveChangesAsync();
            }
        }

        public static List<BookLanguage> GetBookLanguageSeedItems(LibraryManagerContext context)
        {
            var list = new List<BookLanguage>()
            {
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "White Fang"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English")
                },
                new BookLanguage()
                {
                    Book =  context.Books.FirstOrDefault(b => b.Title == "White Fang"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "Ukrainian")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Three Comrades"),
                    Language = context.Languages.FirstOrDefault(x => x.LanguageName == "German") 
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Three Comrades"),
                    Language = context.Languages.FirstOrDefault(x => x.LanguageName == "Ukrainian")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Call of the wild"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English") 
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Call of the wild"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "Ukrainian")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Mysterious Island"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "French") 
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Mysterious Island"),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "Ukrainian")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Sherlock Holmes" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English") 
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Sherlock Holmes" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "Ukrainian")
                }
            };
            return list;
        }
    }
}