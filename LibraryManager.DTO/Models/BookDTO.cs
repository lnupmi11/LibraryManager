using System;
using System.Collections.Generic;
using System.Text;
using LibraryManager.DTO.Checker;

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

        public int Year;

        public string ImageName
        {
            get
            {
                if (Title == null)
                    return "DefaultBook.png";

                var imageName = Title + ".png";
                return ImageChecker.ImageExists(imageName) ? imageName : "DefaultBook.png";
            }
        }
    }
}
