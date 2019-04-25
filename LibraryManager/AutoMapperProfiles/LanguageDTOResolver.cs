using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;

using AutoMapper;

namespace LibraryManager.AutoMapperProfiles
{
    public class LanguageDTOResolver : IValueResolver<Book, BookDTO, IEnumerable<LanguageDTO>>
    {
        public IEnumerable<LanguageDTO> Resolve(Book source, BookDTO destination, IEnumerable<LanguageDTO> destMember, ResolutionContext context)
        {
            var languages = new List<LanguageDTO>();

            foreach( var language in source.Languages)
            {
                var languageDTO = new LanguageDTO
                {
                    Id = language.Language.Id,
                    LanguageName = language.Language.LanguageName
                };
                languages.Add(languageDTO);
            }

            return languages;
        }
    }
}
