﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.DTO.Models
{
    public class BookDTO
    {
        public int Id;

        public string Title;

        public AuthorDTO Author;

        public IEnumerable<GenreDTO> Genres;

        public IEnumerable<LanguageDTO> Languages;

        public double Rating;

        public string Description;

        public int NumberOfPages;
    }
}
