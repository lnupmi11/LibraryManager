using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LibraryManager.DTO.Models;
using LibraryManager.DAL.Entities;

using AutoMapper;

namespace LibraryManager.AutoMapperProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreDTOResolver>())
                .ForMember(dest => dest.Languages, opt => opt.MapFrom<LanguageDTOResolver>());
            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.Genres, opt => opt.MapFrom<GenreResolver>())
                .ForMember(dest => dest.Languages, opt => opt.MapFrom<LanguageResolver>());
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Language, LanguageDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
