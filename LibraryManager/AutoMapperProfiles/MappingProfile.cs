using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LibraryManager.DTO.Models;
using LibraryManager.DAL.Entities;

using AutoMapper;

namespace LibraryManager.API.AutoMapperProfiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
        }
    }
}
