using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.DTO.Models.Manage
{
    public class AddNewBookModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string AuthorSurname { get; set; }

        public SelectList Genres { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        public string SelectedGenre { get; set; }

        public int Year { get; set; }
        public string Image { get; set; }
        
    }
}
