using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DTO.Models;
using LibraryManager.DAL.Entities;
using AutoMapper;

namespace LibraryManager.AutoMapperProfiles
{
    public class GenreDTOResolver : IValueResolver<Book, BookDTO, IEnumerable<GenreDTO>>
    {
        public IEnumerable<GenreDTO> Resolve(Book source, BookDTO destination, IEnumerable<GenreDTO> destMember, ResolutionContext context)
        {
            var genres = new List<GenreDTO>();

            foreach(var genre in source.Genres)
            {
                var genreDTO = new GenreDTO() { Id = genre.GenreId, GenreName = genre.Genre.GenreName };
                genres.Add(genreDTO);
            }

            return genres;
        }
    }
}
