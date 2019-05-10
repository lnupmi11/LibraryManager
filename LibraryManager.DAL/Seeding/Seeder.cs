using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DAL.Context;

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
                NumberOfPages = 252,
                Rating = 8,
                Title = "White Fang",
                Description = "White Fang is part dog and part wolf, and the lone survivor of his family. In his lonely world, he soon learns to follow the harsh law of the North--kill or be killed. But nothing in White Fang\'s life can prepare him for the cruel owner who turns him into a vicious killer. Will White Fang ever know the kindness of a gentle master?",
                Year = 1905
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Remark"),
                NumberOfPages = 496,
                Rating = 9,
                Title = "Three Comrades",
                Description = "The year is 1928. On the outskirts of a large German city, three young men are earning a thin and precarious living. Fully armed young storm troopers swagger in the streets. Restlessness, poverty, and violence are everywhere. For these three, friendship is the only refuge from the chaos around them. Then the youngest of them falls in love, and brings into the group a young woman who will become a comrade as well, as they are all tested in ways they can never have imagined...",
                Year = 1936
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "London"),
                NumberOfPages = 172,
                Rating = 8,
                Title = "Call of the Wild",
                Description = "First published in 1903, The Call of the Wild is regarded as Jack London\'s masterpiece. Based on London\'s experiences as a gold prospector in the Canadian wilderness and his ideas about nature and the struggle for existence, The Call of the Wild is a tale about unbreakable spirit and the fight for survival in the frozen Alaskan Klondike. ",
                Year = 1903
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Verne"),
                NumberOfPages = 723,
                Rating = 7,
                Title = "The Mysterious Island",
                Description = "Five Union prisoners escape from the siege of Richmond in a balloon, are blown off course and crash on an uncharted island. They must learn to rebuild a society for themselves while awaiting rescue. ",
                Year = 1865
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Conan-Doyle"),
                NumberOfPages = 339,
                Rating = 8,
                Title = "Sherlock Holmes",
                Description = "In this book are collected some of Conan Doyle\'s best detective stories, which were made in England in the late 19th century and were first-person-narrated by Dr. Watson. Participant and attentive observer, this narrator records with admiration some of the adventures of his friend who do not fail to surprise him. At every turn we are witnessing the mastery of Sherlock Holmes to solve the most incredible mysteries that will hit the door. The thrilling stories of Sherlock Holmes continue to win readers and creators of all forms of art. This character is so popular that even has a museum dedicated to himself.",
                Year = 1892
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Wolfgang von Goethe"),
                NumberOfPages = 503,
                Rating = 6,
                Title = "Faust",
                Description = "Goethe’s Faust reworks the late medieval myth of a brilliant scholar so disillusioned he resolves to make a contract with Mephistopheles. The devil will do all he asks on Earth and seeks to grant him a moment in life so glorious that he will wish it to last forever. But if Faust does bid the moment stay, he falls to Mephisto and must serve him after death. In this first part of Goethe’s great work, the embittered thinker and Mephistopheles enter into their agreement, and soon Faust is living a rejuvenated life and winning the love of the beautiful Gretchen. But in this compelling tragedy of arrogance, unfulfilled desire, and self-delusion, Faust heads inexorably toward an infernal destruction.",
                Year = 1832
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Heine"),
                NumberOfPages = 44,
                Rating = 7,
                Title = "The Lorelei",
                Description = "The Lorelei (Loreley) is a Siren in German mythology that sits on the cliff above the Rhine, combing her golden hair, unwittingly distracted sailors with her beauty and song, causing them to crash on the rocks.",
                Year = 1824
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Verne"),
                NumberOfPages = 394,
                Rating = 9,
                Title = "Twenty Thousand Leagues Under the Sea",
                Description = "French naturalist Dr. Aronnax embarks on an expedition to hunt down a sea monster, only to discover instead the Nautilus, a remarkable submarine built by the enigmatic Captain Nemo. Together Nemo and Aronnax explore the underwater marvels, undergo a transcendent experience amongst the ruins of Atlantis, and plant a black flag at the South Pole. But Nemo\'s mission is one of revenge-and his methods coldly efficient.",
                Year = 1869
            });
            list.Add(new Book()
            {
                Author = context.Authors.FirstOrDefault(x => x.LastName == "Verne"),
                NumberOfPages = 252,
                Rating = 8,
                Title = "Around the World in Eighty Days",
                Description = "To go around the world...in such a short time and with the means of transport currently available, was not only impossible, it was madness",
                Year = 252
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
            list.Add(new Author()
            {
                FirstName = "Johann",
                LastName = "Wolfgang von Goethe",
                NumberOfWrittenBooks = 13
            });
            list.Add(new Author()
            {
                FirstName = "Heinrich",
                LastName = "Heine",
                NumberOfWrittenBooks = 4
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
                GenreName = "Poem"
            });
            list.Add(new Genre()
            {
                GenreName = "Novel"
            });
            list.Add(new Genre()
            {
                GenreName = "Biography"
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
                },
                new BookGenre()
                {
                Book = context.Books.FirstOrDefault(b => b.Title == "Faust"),
                Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Poem")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Lorelei"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Poem")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Twenty Thousand Leagues Under the Sea"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Adventures")
                },
                new BookGenre()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Around the World in Eighty Days"),
                    Genre = context.Genres.FirstOrDefault(g => g.GenreName == "Adventures")
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
                    Book = context.Books.FirstOrDefault(b => b.Title == "Faust" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Faust" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "German")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Lorelei" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "The Lorelei" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "German")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Twenty Thousand Leagues Under the Sea" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Twenty Thousand Leagues Under the Sea" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "French")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Around the World in Eighty Days" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "English")
                },
                new BookLanguage()
                {
                    Book = context.Books.FirstOrDefault(b => b.Title == "Around the World in Eighty Days" ),
                    Language = context.Languages.FirstOrDefault(l => l.LanguageName == "French")
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