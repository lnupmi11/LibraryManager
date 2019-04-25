using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.DAL.Entities;
using LibraryManager.DTO.Models;
using AutoMapper;

namespace LibraryManager.AutoMapperProfiles
{
    public class GenreResolver: IValueResolver<BookDTO, Book, ICollection<BookGenre>>
    {
        public ICollection<BookGenre> Resolve(BookDTO source, Book destination, ICollection<BookGenre> destMember, ResolutionContext context)
    {
        var genres = new List<BookGenre>();

        foreach (var genre in source.Genres)
        {
                var bookGenre = new BookGenre
                {
                    Book = destination,
                    Genre = new Genre { GenreName = genre.GenreName }
                };
                genres.Add(bookGenre);
        }

        return genres;
    }
}
}
