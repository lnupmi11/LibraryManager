using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;

using AutoMapper;

namespace LibraryManager.AutoMapperProfiles
{
    public class LanguageResolver : IValueResolver<BookDTO, Book, ICollection<BookLanguage>>
    {
        public ICollection<BookLanguage> Resolve(BookDTO source, Book destination, ICollection<BookLanguage> destMember, ResolutionContext context)
        {
            var languages = new List<BookLanguage>();

            foreach(var language in source.Languages)
            {
                var bookLanguage = new BookLanguage
                {
                    Book = destination,
                    Language = new Language() { LanguageName = language.LanguageName }
                };

                languages.Add(bookLanguage);
            }

            return languages;
        }
    }
}
