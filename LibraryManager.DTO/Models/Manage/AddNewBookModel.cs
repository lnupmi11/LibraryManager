﻿using Microsoft.AspNetCore.Mvc.Rendering;
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

        public MultiSelectList Genres { get; set; }

        public SelectList Languages { get; set; }

        [Required]
        public int NumberOfPages { get; set; }


        [Required]
        public string Description { get; set; }

        public string[] SelectedGenre { get; set; }
        public string SelectedLanguage { get; set; }

        public int Year { get; set; }
        public string Image { get; set; }
        public string PDF { get; set; }
        
    }
}
