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
        public string Author { get; set; }

        public SelectList Genres { get; set; }

        [Required]
        public int NumberOfPages { get; set; }

        public double Rating { get; set; }

        [Required]
        public string Description { get; set; }

        public string SelectedGenre { get; set; }
    }
}
